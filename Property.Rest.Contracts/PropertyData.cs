using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Norm;
using System;
using System.Collections.Generic;

namespace Property.Rest.Contracts
{
    [DataContract]
    public class PropertyData 
    {
        public Norm.ObjectId Id { get; set; }

        [DataMember]
        public string propertyId
        {
            get { return ((Id != null) ? Id.ToString() : null); }
            set {
                Norm.ObjectId Test;
                Norm.ObjectId.TryParse(value, out Test);
                Id = Test;
            }
        }
        [DataMember]
        public int active { get; set; }

        [DataMember]
        public PropertyIdentification propertyIdentification { get; set; }

        [DataMember]
        public ListingType propertyListingType { get; set; }

        [DataMember]
        public Address propertyAddress { get; set; }

        [DataMember]
        public PropertyDetails propertyDetails { get; set; }

        [DataMember]
        public PropertyGeoLoc propertyGeoLoc { get; set; }

        [DataMember]
        public PropertyPrice propertyPrice { get; set; }

        [DataMember]
        public PropertyAccount propertyAccount { get; set; }

        [DataMember]
        public ListingAgent listingAgent { get; set; }

        //[DataMember]

        //public DigitalContent digitalContent { get; set; }

        [DataMember]
        public string keywords { get; set; }

        [DataMember]
        public DateTime dateLastUpdated { get; set; }

        [DataMember]
        public string dateLastUpdatedString { get { return dateLastUpdated.ToString("o"); } set { } }

    }

    [DataContract]
    public class Address
    {

        [DataMember]
        public string street { get; set; }

        [DataMember]
        public string street2 { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string county { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public string zip { get; set; }
    }
    [DataContract]
    public class ListingType
    {

        [DataMember]
        public bool forSale { get; set; }

        [DataMember]
        public bool forRent { get; set; }

        [DataMember]
        public bool saleAgent { get; set; }

        [DataMember]
        public bool saleOwner { get; set; }

        [DataMember]
        public bool saleNewConstructon { get; set; }

        [DataMember]
        public bool saleForeclosure { get; set; }

    }
    [DataContract]
    public class PropertyIdentification
    {
        [DataMember]
        public string customPropertyID { get; set; }

        [DataMember]
        public string mlsID { get; set; }

        [DataMember]
        public string otherID { get; set; }


    }
    [DataContract]
    public class PropertyDetails
    {
        [DataMember]
        public string beds { get; set; }

        [DataMember]
        public string baths { get; set; }

        [DataMember]
        public double squareFeet { get; set; }

        [DataMember]
        public int lotSize { get; set; }

        [DataMember]
        public int yearBuilt { get; set; }

        [DataMember]
        public double hoa { get; set; }

        [DataMember]
        public string propertyType { get; set; }

        [DataMember]
        public string propertyDescription { get; set; }

        [DataMember]
        public string imageUrl { get; set; }
    }
    [DataContract]
    public class PropertyGeoLoc
    {
        [DataMember]
        public double x { get; set; }  // Longitude

        [DataMember]
        public double y { get; set; } // Latitude

    }
    [DataContract]
    public class PropertyPrice
    {
        [DataMember]
        public double price { get; set; }

        [DataMember]
        public double lastPrice { get; set; }
    }
    [DataContract]
    public class PropertyAccount
    {
        [DataMember]
        public int daysListed { get; set; }

        [DataMember]
        public DateTime dateListed { get; set; }
      
        [DataMember]        
        public string dateListedString { get { return dateListed.ToString("o");  } set { } }

        [DataMember]
        public DateTime dateExpiry { get; set; }

        [DataMember]
        public string dateExpiryString { get { return dateExpiry.ToString("o"); }  set { } }

    }
    [DataContract]
    public class ListingAgent
    {
        [DataMember]
        public string listingAgentID { get; set; }

        [DataMember]
        public string fullName { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string phone { get; set; }

        [DataMember]
        public string cellPhone { get; set; }

        [DataMember]
        public string fax { get; set; }
    }

    //[DataContract]
    //public class DigitalContent
    //{
    //    [DataMember]
    //    public Images images { get; set; }
    //    [DataMember]
    //    public Videos video { get; set; }

    //}

    //[DataContract]
    //public class Images
    //{
    //    [DataMember]
    //    public int total { get; set; }
    //    [DataMember]
    //    public List<Image> image { get; set; }

    //};

    //[DataContract]
    //public class Videos
    //{
    //    [DataMember]
    //    public int total { get; set; }
    //    [DataMember]
    //    public List<Video> video { get; set; }

    //};
    //[DataContract]
    //public class Image
    //{
    //    [DataMember]
    //    public string title  { get; set; }
    //    [DataMember]
    //    public string mediaUrl { get; set; }
    //    [DataMember]
    //    public string url { get; set; }
    //    [DataMember]
    //    public string displayUrl { get; set; }
    //    [DataMember]
    //    public string description { get; set; }
    //    [DataMember]
    //    public int width { get; set; }
    //    [DataMember]
    //    public int height { get; set; }
    //    [DataMember]
    //    public Thumbnail thumbnail { get; set; }
    //    [DataMember]
    //    public int deleted { get; set; }
    //};
    //[DataContract]
    //public class Video
    //{
    //    [DataMember]
    //    public string title { get; set; }
    //    [DataMember]
    //    public string playUrl { get; set; }
    //    [DataMember]
    //    public int runtime { get; set; }
    //    [DataMember]
    //    public string description { get; set; }       
    //    [DataMember]
    //    public Thumbnail thumbnail { get; set; }
    //    [DataMember]
    //    public int deleted { get; set; }
    //};

    //[DataContract]
    //public class Thumbnail
    //{
    //    [DataMember]
    //    public string url { get; set; }
    //    [DataMember]
    //    public string contentType { get; set; }
    //    [DataMember]
    //    public int width { get; set; }
    //    [DataMember]
    //    public int height { get; set; }
    //    [DataMember]
    //    public int fileSize { get; set; }
    //}

    //"Image":{
    //     "Total":92,
    //     "Offset":0,
    //     "Results":[
    //        {
    //           "Title":"Microsoft Deutschland GmbH auf der CeBIT 2006.",
    //           "MediaUrl":"http:\/\/www.microsoft.com\/germany\/presseservice\/images\/pressemappen\/cebit2006\/Xbox-360_5.jpg",
    //           "Url":"http:\/\/www.microsoft.com\/germany\/presseservice\/service\/pressemappen\/cebit2006.mspx",
    //           "DisplayUrl":"http:\/\/www.microsoft.com\/germany\/presseservice\/service\/pressemappen\/cebit2006.mspx",
    //           "Width":3259,
    //           "Height":3264,
    //           "Thumbnail":{
    //              "Url":"http:\/\/ts2.images.live.com\/images\/thumbnail.aspx?q=2847678867077&id=b3ba5b922c04d322d937275335c8cf75",
    //              "ContentType":"image\/jpeg",
    //              "Width":159,
    //              "Height":160,
    //              "FileSize":2624
    //           }
    //        },
    //        {
    //              "Title":"Xbox, Xbox.com, and Xbox LIVE Advertising - Microsoft Advertising",
    //              "PlayUrl":"http:\/\/advertising.microsoft.com\/gaming\/xbox-advertising",
    //              "RunTime":78156,
    //              "ClickThroughPageUrl":"http:\/\/bing.com\/video\/results.aspx?q=xbox&scope=video&docid=663626973563&FORM=SOAPGN",
    //              "StaticThumbnail":{
    //                  "Url":"http:\/\/ts4.images.live.com\/video\/thumbnail.aspx?q=663626973563&id=30fc59179deb3182887b21563a2dea4c",
    //                  "ContentType":"image\/jpeg",
    //                  "Width":160,
    //                  "Height":90,
    //                  "FileSize":2870
    //              }
    //        }
    // ]
    //}
}
