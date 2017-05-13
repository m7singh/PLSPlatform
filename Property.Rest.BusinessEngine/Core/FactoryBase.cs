using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace IDesign.Core.Business
{
    public abstract class FactoryBase<TBusinessObject, TBusinessCollection, TBusinessFactory, TIdType> where TBusinessObject : new() where TBusinessCollection : CollectionBase<TBusinessObject>, new()
    {
        protected Dictionary<string, int> _OrdinalMappings = new Dictionary<string, int>();

        protected object GetOrdinalMapping(IDataReader reader, string columnName)
        {
        	int ordinal = -1;
            if(!_OrdinalMappings.ContainsKey(columnName))
            {
            	ordinal = reader.GetOrdinal(columnName);
                _OrdinalMappings.Add(columnName, ordinal);
            }
            else
                ordinal = _OrdinalMappings[columnName];

            return reader[ordinal];
        }

        public TBusinessObject GetOne(IDataReader reader)
        {
        	TBusinessObject item = default(TBusinessObject);
            using (reader)
            	if(reader.Read()) item = this.GetRow(reader);
            return item;
        }

        public TBusinessCollection GetMany(IDataReader reader)
        {
        	TBusinessCollection collection = new TBusinessCollection();
            using (reader)
            {
                while (reader.Read())
                {
            	    CollectionBase<TBusinessObject> collectionBase;
                    collectionBase = (CollectionBase<TBusinessObject>)collection;
                    collection.Add(this.GetRow(reader));
                }
            }
            return collection;
        }

        public TBusinessObject GetRow(IDataReader reader)
        {
        	return this.GetRow(reader, "");
        }

        public abstract TBusinessObject GetRow(IDataReader reader, string tablePrefix);

        protected virtual string _InsertedIdFieldName { get { return "InsertedId"; } } // the name of the field returned by Select @@IDENTITY in stored procs
        
        protected TIdType UpdateNew(IDataReader reader)
        {
            TIdType newId = default(TIdType);
            using (reader)
                if(reader.Read()) newId = (TIdType)(reader[_InsertedIdFieldName]);
            return newId;
        }
        
        protected void UpdateExisting(IDataReader reader)
        {
        	reader.Dispose();
            // this method doesn't do much, but is here for futurization purposes
        }

        public abstract TBusinessObject GetById(TIdType id);

        public abstract TBusinessCollection GetAll();

        public abstract TIdType Insert(TBusinessObject businessObject);

        public abstract void Update(TBusinessObject businessObject);

        public abstract void Delete(TIdType id);
    }
}
