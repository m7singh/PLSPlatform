using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace IDesign.Core.Data
{
    public abstract class DalBase : IDisposable
    {
        protected DalBase(string connectionStringName)
        {
            string connStr = string.Empty;

            try { connStr = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString; }
            catch { connStr = "mainConnStr"; }

            string provider = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            if (string.IsNullOrEmpty(provider))
                provider = "System.Data.SqlClient";

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            _Conn = factory.CreateConnection();
            _Conn.ConnectionString = connStr;
            _Conn.Open();

            _Cmd = _Conn.CreateCommand();
        }

        ~DalBase()
        {
            Dispose(false);
        }

        private bool disposed = false;

        protected IDbConnection _Conn = null;
        protected IDbCommand _Cmd = null;

        protected IDbCommand CreateCommand(string sqlText, CommandType cmdType)
        {
            return CreateCommand(sqlText, null, cmdType);
        }

        protected IDbCommand CreateCommand(string sqlText, IDataParameter[] dbParams, CommandType cmdType)
        {
            _Cmd.CommandText = sqlText;
            _Cmd.CommandType = cmdType;
            return CreateCommand(_Conn, _Cmd, dbParams);
        }

        protected IDbCommand CreateCommand(IDbConnection conn, IDbCommand cmd, IDataParameter[] cmdParams)
        {
            if (cmdParams != null)
            {
                foreach (IDbDataParameter param in cmdParams)
                    cmd.Parameters.Add(param);
            }

            return cmd;
        }

        protected IDataParameter GetParameter(string paramName, object paramValue)
        {
            IDataParameter param = _Cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            return param;
        }

        protected IDataReader GetReader(string sqlText, CommandType cmdType)
        {
            return GetReader(sqlText, cmdType, null);
        }

        protected IDataReader GetReader(string sqlText, CommandType cmdType, IDataParameter[] param)
        {
            return GetReader(CreateCommand(sqlText, param, cmdType));
        }

        protected IDataReader GetReader(IDbCommand cmd)
        {
            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected int ExecuteSql(string sqlText, IDbDataParameter[] dbParams)
        {
            return ExecuteSql(CreateCommand(sqlText, dbParams, CommandType.StoredProcedure));
        }

        protected int ExecuteSql(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Conn.Dispose();
                }

                disposed = true;
            }
        }

    }
}
