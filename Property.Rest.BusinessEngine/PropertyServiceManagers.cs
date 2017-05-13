using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.Rest.Contracts;
using Property.Rest.Repository.Context;

namespace Property.Rest.BusinessEngine
{
    public class PropertyServiceManagers : IDisposable
    {
        public PropertyData GetPropertyInfo(string propertyid)
        {
            //DbContext.Current.Single<PropertyData>(d => d.Id == propertyid);

            // DbContext.Current.<Dragon>(d => d.Id == dragon.Id);

            return DbContext.Current.Single<PropertyData>(d => d.Id == propertyid); ;
        }

        public PropertyData[] GetProperties()
        {
            return DbContext.Current.All<PropertyData>().ToArray<PropertyData>();
            //throw new NotImplementedException();
        }
        public PropertyData[] GetProperties(string state, string zip)
        {
            if (!string.IsNullOrEmpty(state) && string.IsNullOrEmpty(zip))
                return DbContext.Current.All<PropertyData>(d => d.propertyAddress.state == state).ToArray<PropertyData>();
            if (string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(zip))
                return DbContext.Current.All<PropertyData>(d => d.propertyAddress.zip == zip).ToArray<PropertyData>();
            if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(zip))
                return DbContext.Current.All<PropertyData>(d => d.propertyAddress.state == state && d.propertyAddress.zip == zip).ToArray<PropertyData>();
            return null;
        }
        public void InsertProperty(PropertyData data)
        {
            DbContext.Current.Add<PropertyData>(data);          
        }
     
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                DbContext.Current.Dispose();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PropertyServiceManagers() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
