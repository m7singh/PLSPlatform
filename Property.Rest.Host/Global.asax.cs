using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Property.Rest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Property.Rest.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            // Create Json.Net formatter serializing DateTime using the ISO 8601 format
            //JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            //serializerSettings.Converters.Add(new IsoDateTimeConverter());
            //GlobalConfiguration.Configuration.Formatters[0] = new JsonNetFormatter(serializerSettings);

            // Convert all dates to UTC
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;



            RouteTable.Routes.Add(
               new ServiceRoute("api",
                   new ServiceHostFactory(), typeof(PropertyService)));

            // Convert all dates to UTC
            
        }
    }
}
