using System;

namespace SharePointMigration.Model
{
    public class NonHoustonMLSDetailsModel : ISiteModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Division { get; set; }
        public string Community { get; set; }
        public string JobNumber { get; set; }
        public string StreetAddress { get; set; }
        public string MLSNumber { get; set; }
        public string TXMLSNumber { get; set; }
        public string Photo { get; set; }
        public string ListedPrice { get; set; }
        public string RealtorBonus { get; set; }
        public DateTime? DatePosted { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime? DateReleased { get; set; }
        public string SalesStatus { get; set; }
        public DateTime? SalesRatifiedDate { get; set; }
        public DateTime? DateClosed { get; set; }
        public string ContractPrice { get; set; }
    }

    public static class NonHoustonMLSDetails
    {
        public const string Id = "Id";
        public const string Status = "Status";
        public const string Division = "Division";
        public const string Community = "Community";
        public const string JobNumber = "Title";
        public const string StreetAddress = "StreetAddress";
        public const string MLSNumber = "NewMLSNumber";
        public const string TXMLSNumber = "NewTXMLSnumber";
        public const string Photo = "Photo";
        public const string ListedPrice = "ListedPrice";
        public const string RealtorBonus = "RealtorBonus";
        public const string DatePosted = "DatePosted";
        public const string Longitude = "Longitude";
        public const string Latitude = "Latitude";
        public const string DateReleased = "DateReleased";
        public const string SalesStatus = "SalesStatus";
        public const string SalesRatifiedDate = "SalesRatifiedDate";
        public const string DateClosed = "DateClosed";
        public const string ContractPrice = "ContractPrice";
    }
}
