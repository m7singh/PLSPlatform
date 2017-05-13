using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Property.Rest.Contracts;
using System.Web.Script.Serialization;
using System.Text;

namespace Property.Rest.Tests
{
    [TestClass]
    public class HttpTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Get()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/propertyservice/json/property").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }

        [TestMethod]
        public void Post()
        {
            HttpClient client = new HttpClient();

            PropertyData data = new PropertyData()
            {
                propertyIdentification = new PropertyIdentification()
                {
                    customPropertyID = "000001",
                    mlsID = "MSG00001",
                    otherID = ""
                },

                propertyAddress = new Address()
                {
                    street = "1234 Some St",
                    county = "Gotham",
                    city = "Gotham City",
                    state = "CA",
                    zip = "88888",
                    street2 = "400"
                },
                propertyDetails = new PropertyDetails()
                {
                    baths = "1",
                    beds = "2",
                    hoa = 300,
                    lotSize = 7000,
                    propertyType = "SFR",
                    squareFeet = 3000,
                    yearBuilt = 1990
                },
                propertyPrice = new PropertyPrice()
                {
                    price = 200000,
                    lastPrice = 300000
                },
                active = 1,
                propertyAccount = new PropertyAccount()
                {
                    dateListed = DateTime.UtcNow,
                    dateExpiry = DateTime.UtcNow.AddMonths(90),
                    daysListed = 2
                },
                listingAgent = new ListingAgent ()
                {
                    listingAgentID = "12345",
                    fullName = "John Doe"
                },               
             
                keywords = "2 Full Bath, Large backyard",
              
                propertyListingType = new ListingType()
                {
                    forRent = false ,
                    forSale = true,
                    saleAgent = false,
                    saleForeclosure = true,
                    saleNewConstructon = false,
                    saleOwner = true
                }
               
            };

            var postResponse = client.PostAsync("http://localhost:46268/api/psvc/json/property", new StringContent(
                    new JavaScriptSerializer().Serialize(data), Encoding.UTF8, "application/json")).Result;


            //var postResponse = client.PostAsJsonAsync<ZipCodeData>(
            //    "http://localhost:46268/api/zipservice/json/zip", data).Result;

            //var getResponse = client.GetStringAsync(
            //    "http://localhost:46268/api/zipservice/json/zip/99999").Result;
            //ZipCodeData zipData = Json.Decode<ZipCodeData>(getResponse);

            //Assert.AreEqual(zipData.Zip, "99999");
            //Assert.AreEqual(zipData.City, "Gotham City");
            //Assert.AreEqual(zipData.State, "NY");

            //var deleteResponse = client.DeleteAsync(
            //    "http://localhost:27909/api/zipservice/json/zip/99999").Result;

            //Assert.IsNull(null);
        }

        [TestMethod]
        public void GetProperties()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/psvc/json/property").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }
        [TestMethod]
        public void GetPropertiesBasedonCAState()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/psvc/json/property?state=CA&zip=").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }
        [TestMethod]
        public void GetPropertiesBasedonNYState()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/psvc/json/property?state=NY&zip=").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }

        [TestMethod]
        public void GetPropertiesBasedonCAState88888()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/psvc/json/property?state=CA&zip=88888").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }
        [TestMethod]
        public void GetPropertiesBasedonNYState99999()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetStringAsync(
                "http://localhost:46268/api/psvc/json/property?state=NY&zip=99999").Result;
            //PropertyData data = Json.Decode<PropertyData>(getResponse);

            Assert.IsNotNull(getResponse);
            //Assert.AreEqual(data.City, "Lincoln Park");
            //Assert.AreEqual(data.State, "NJ");
            //Assert.AreEqual(data.Zip, "07035");
        }
    }
}
