using Norm;

namespace Property.Rest.Contracts
{
    public interface IPropertyData
    {
        int active { get; set; }
        ObjectId Id { get; set; }
        string keywords { get; set; }
        ListingAgent listingAgent { get; set; }
        PropertyAccount propertyAccount { get; set; }
        Address propertyAddress { get; set; }
        PropertyDetails propertyDetails { get; set; }
        PropertyGeoLoc propertyGeoLoc { get; set; }
        string propertyId { get; set; }
        PropertyIdentification propertyIdentification { get; set; }
        ListingType propertyListingType { get; set; }
        PropertyPrice propertyPrice { get; set; }
    }
}