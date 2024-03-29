Url,%   =http://localhost:46268/api/propertiesHeader,    =Content-Type: application/json
CertIssuer,   =edge.krollfactualdata.comContent,[  ={
    "active": 1,
   "propertyIdentification": {
      "customPropertyID": "000001",
      "mlsID": "MSG00001",
      "otherID": ""
   },
   "propertyListingType": {
      "forSale": true,
      "forRent": false,
      "saleAgent": false,
      "saleOwner": true,
      "saleNewConstructon": false,
      "saleForeclosure": true
   },
   "propertyAddress": {
      "street": "1234 Some St",
      "street2": "400",
      "city": "Gotham City",
      "county": "Gotham",
      "state": "CA",
      "zip": "88888"
   },
   "propertyDetails": {
      "beds": "2",
      "baths": "1",
      "squareFeet": 3000,
      "lotSize": 7000,
      "yearBuilt": 1990,
      "hoa": 300,
      "propertyType": "SFR"
   },
 "propertyGeoLoc": null,
   "propertyPrice": {
      "price": 200000,
      "lastPrice": 300000
   },
   "propertyAccount": {
      "dateExpiry":"\/Date(-62135568000000)\/",
      "dateListed":"\/Date(-62135568000000)\/",
      "daysListed": 2
    
   },
   "listingAgent": {
      "listingAgentID": "12345",
      "listingAgentFullName": "John Doe",
      "listingAgentFirstName": null,
      "listingAgentLastName": null,
      "listingAgentEmail": null,
      "listingAgentPhone": null,
      "listingAgentCellPhone": null,
      "listingAgentFax": null
   },
   "keywords": "2 Full Bath, Large backyard"
}Result,  =Status Code is 200
HTTP/1.1 200 OK
Cache-Control: private
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/10.0
X-AspNet-Version: 4.0.30319
X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc29ueXN6XERvY3VtZW50c1xWaXN1YWwgU3R1ZGlvIDIwMTVcUHJvamVjdHNcbW9uZ29hcHBcUHJvcGVydHlcUHJvcGVydHkuUmVzdC5Ib3N0XGFwaVxwcm9wZXJ0aWVz?=
X-Powered-By: ASP.NET
Date: Mon, 17 Apr 2017 07:32:35 GMT
Content-Length: 1138

{"active":1,"dateLastUpdated":"\/Date(-62135568000000-0800)\/","dateLastUpdatedString":"0001-01-01T00:00:00.0000000","keywords":"2 Full Bath, Large backyard","listingAgent":{"cellPhone":null,"email":null,"fax":null,"firstName":null,"fullName":null,"lastName":null,"listingAgentID":"12345","phone":null},"propertyAccount":{"dateExpiry":"\/Date(-62135568000000)\/","dateExpiryString":"0001-01-01T08:00:00.0000000Z","dateListed":"\/Date(-62135568000000)\/","dateListedString":"0001-01-01T08:00:00.0000000Z","daysListed":2},"propertyAddress":{"city":"Gotham City","county":"Gotham","state":"CA","street":"1234 Some St","street2":"400","zip":"88888"},"propertyDetails":{"baths":"1","beds":"2","hoa":300,"lotSize":7000,"propertyDescription":null,"propertyType":"SFR","squareFeet":3000,"yearBuilt":1990},"propertyGeoLoc":null,"propertyId":"09599e01a47c60e40f000000","propertyIdentification":{"customPropertyID":"000001","mlsID":"MSG00001","otherID":""},"propertyListingType":{"forRent":false,"forSale":true,"saleAgent":false,"saleForeclosure":true,"saleNewConstructon":false,"saleOwner":true},"propertyPrice":{"lastPrice":300000,"price":200000}}