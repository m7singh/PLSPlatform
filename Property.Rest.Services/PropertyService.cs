using Property.Rest.BusinessEngine;
using Property.Rest.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Property.Rest.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PropertyService : IPropertyContract
    {

        public PropertyData[] GetProperties()
        {
            using (PropertyServiceManagers propertyServiceManagers = new PropertyServiceManagers())
            {
                return propertyServiceManagers.GetProperties();
            }
        }

        public PropertyData[] GetPropertiesBasedOnStateZip(string state, string zip)
        {
            using (PropertyServiceManagers propertyServiceManagers = new PropertyServiceManagers())
            {
                return propertyServiceManagers.GetProperties(state, zip);
            }
        }

        public void DeleteProperty(string propertyid)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentDateTime()
        {
            throw new NotImplementedException();
        }

        public PropertyData[] GetPropertiesForState(string state)
        {
            throw new NotImplementedException();
        }

        public PropertyData[] GetPropertiesInRange(string propertyid, double miles)
        {
            throw new NotImplementedException();
        }

        public PropertyData GetPropertyInfo(string propertyid)
        {
            PropertyData propertyData = null;

            using (PropertyServiceManagers propertyServiceManagers = new PropertyServiceManagers())
            {
                propertyData = propertyServiceManagers.GetPropertyInfo(propertyid);
            }
            //if (propertyData != null)
            //{
            //    data = GetZipCodeData(zipCode);
            //}    
            return propertyData;
        }
        //????

        public PropertyData InsertProperty(PropertyData data)
        {
            using (PropertyServiceManagers propertyServiceManagers = new PropertyServiceManagers())
            {
                propertyServiceManagers.InsertProperty(data);
            }

            return data;
        }

        //public void InsertProperty(SearchCirteria data)
        //{

        //    new PropertyServiceManagers().InsertProperty(data);
        //}

        public void UpdateProperty(string propertyid, PropertyData data)
        {
            throw new NotImplementedException();
        }

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "/oj", BodyStyle = WebMessageBodyStyle.Bare)]
        //public void GetData(string param0, string param1)
        //{

        //    var body = Encoding.UTF8.GetString(System.ServiceModel.OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>());

        //    var body2 = System.ServiceModel.OperationContext.Current.RequestContext.RequestMessage.GetBody<System.IO.Stream>();

        //    var body3 =  System.ServiceModel.OperationContext.Current.RequestContext.RequestMessage.ToString();

        //    StreamReader reader = new StreamReader(body2);
        //    string text = reader.ReadToEnd();

        //    //object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(body3);

        //    //throw new NotImplementedException();

        //}

    }

}
