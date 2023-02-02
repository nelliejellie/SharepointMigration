using System;

namespace SharePointMigration.Model
{
    public class HoustonMLSDetailsModel : ISiteModel
    {
        public string Id { get; set; }
       public string ItemsReceivedTwo { get; set; }
       public string Division { get; set; }
       public string Status { get; set; }
       public string Community { get; set; }
        public string StreetAddress { get; set; }
        public string StreetName { get; set; }
        public string JobNumber { get; set; }
        public string MLSTeamMember { get; set; }
        public string MLSNumber { get; set; }
        public DateTime? MLSNumberDate { get; set; }
        public string Photo { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? DateReleased { get; set; }
        public string GeoCode { get; set; }
        public string StageConstruction { get; set; }
        public string RealtorBonus { get; set; }
        public string SalesStatus { get; set; }
        public string SalesRatifiedDate { get; set; }
        public string ContractPrice { get; set; }
        public DateTime? DateFormReceived { get; set; }
    }

    public static class HoustonMLSDetails
    {
        public const string Id = "Id";
        public const string ItemsReceivedTwo = "ItemsReceived2";
        public const string Division = "Divsion";
        public const string Status = "Status";
        public const string Community = "Community";
        public const string StreetAddress = "StreetAddress";
        public const string JobNumber = "Title";
        public const string MLSTeamMember = "MLS_x0020_Team_x0020_Member";
        public const string MLSNumber = "MLSnumber";
        public const string MlSNumberDate = "MLS_x0020_Number_x0020_Date";
        public const string Photo = "Photo";
        public const string DatePosted = "DatePosted";
        public const string DateReleased = "DateReleased";
        public const string GeoCode = "GeoCode";
        public const string StageConstruction = "StageConstruction";
        public const string RealtorBonus = "RealtorBonus";
        public const string SalesStaus = "SalesStatus";
        public const string SalesRatifiedDate = "SaleRatifiedDate";
        public const string ContractPrice = "ContractPrice";
        public const string DateFormReceived = "DateFormReceived";
        public const string MLSNumberDate = "";

    }
}
