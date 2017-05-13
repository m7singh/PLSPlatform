using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Property.Rest.Contracts
{
    [ServiceContract]
    public interface IPropertyContract
    {
        [OperationContract]
        [WebGet(UriTemplate = "properties")]
        PropertyData[] GetProperties();

        [OperationContract]
        [WebGet(UriTemplate = "properties/state/{state}")]
        PropertyData[] GetPropertiesForState(string state);

        [OperationContract]
        [WebGet(UriTemplate = "properties/state/{state}/zip/{zip}")]
        PropertyData[] GetPropertiesBasedOnStateZip(string state,string zip);
        
        [OperationContract]
        [WebGet(UriTemplate = "properties/{propertyid}")]
        PropertyData GetPropertyInfo(string propertyid);     

        [OperationContract]
        [WebGet(UriTemplate = "properties/{propertyid}?miles={miles}")]
        [AspNetCacheProfile("CacheFor10SecondsWithMiles")]
        PropertyData[] GetPropertiesInRange(string propertyid, double miles);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/properties")]
        PropertyData InsertProperty(PropertyData data);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/properties/{propertyid}")]
        void UpdateProperty(string propertyid, PropertyData data);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/properties/{propertyid}")]
        void DeleteProperty(string propertyid);

        [OperationContract]
        [WebGet(UriTemplate = "/datetime")]
        [AspNetCacheProfile("CacheFor10Seconds")]
        string GetCurrentDateTime();

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "/oj/{param0}/{param1}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        //void GetData(string param0, string param1);

    }
}
