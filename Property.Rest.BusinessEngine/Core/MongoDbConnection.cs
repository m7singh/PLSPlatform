using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MongoDB.Driver;

namespace Property.Rest.BusinessEngine.Core.Database.Sql.MongoDb
{
    public class MongoDbConnection : IDbConnection
    {
        private String _connectionString;

        private MongoServer _server;

        private MongoDatabase _db;

        private String _dbName;

        public MongoDbConnection(String connectionString, String dbName)
        {
            this.ConnectionString = connectionString;
            this._dbName = dbName;
        }

        #region IDbConnection implementation
        //public IDbTransaction BeginTransaction()
        //{
        //    Console.WriteLine("begin transaction");
        //    _server.RequestStart(_db);
        //    return null;
        //}


        //public IDbTransaction BeginTransaction(IsolationLevel il)
        //{
        //    Console.WriteLine("begib transaction");
        //    _server.RequestDone();
        //    return null;
        //}


        public void ChangeDatabase(string databaseName)
        {
            Console.WriteLine("change database");
            _db = _server.GetDatabase(databaseName);
            _dbName = _db.Name;
        }


        public void Close()
        {
            Console.WriteLine("close connection");
            _server.Disconnect();
        }


        public IDbCommand CreateCommand()
        {
            Console.WriteLine("create command - not impl");
            throw new System.NotImplementedException();
        }


        public void Open()
        {
            Console.WriteLine("open DB connection:" + _connectionString);
            _server = MongoServer.Create(_connectionString);
            _server.Connect();
            if (!String.IsNullOrEmpty(_dbName))
                ChangeDatabase(_dbName);
        }

        public IEnumerable<string> getDatabases()
        {
            return _server.GetDatabaseNames();
        }

        public IEnumerable<string> getCollections()
        {
            return _db.GetCollectionNames();
        }

        public string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
            set
            {
                this._connectionString = value;
            }
        }

        public MongoCredentials getDataBaseCredentials()
        {
            return _db.Credentials;
        }

        public int ConnectionTimeout
        {
            get
            {
                Console.WriteLine("get conn timeout - not implemented");
                throw new System.NotImplementedException();
            }
        }


        public string Database
        {
            get
            {
                Console.WriteLine("get db name");
                return _dbName;
            }
        }


        public ConnectionState State
        {
            get
            {
                ConnectionState result = ConnectionState.Broken;
                switch (_server.State)
                {
                    case MongoServerState.Connected:
                        result = ConnectionState.Open;
                        break;
                    case MongoServerState.Connecting:
                        result = ConnectionState.Connecting;
                        break;
                    case MongoServerState.Disconnected:
                        result = ConnectionState.Closed;
                        break;
                    default:
                        result = ConnectionState.Broken;
                        break;
                }
                Console.WriteLine("get connection state:" + result.ToString());
                return result;
            }
        }

        #endregion
        #region IDisposable implementation
        public void Dispose()
        {
            Console.WriteLine("dispose");
            _server.Disconnect();
            _db = null;
            _server = null;
        }

        #endregion

    }
}