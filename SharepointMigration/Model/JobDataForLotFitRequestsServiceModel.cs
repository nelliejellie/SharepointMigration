namespace SharePointMigration.Model
{
    public class JobDataForLotFitRequestsServiceModel : ISiteModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string RegionCity { get; set; }
        public string Division { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string JobNumber { get; set; }
        public string Status { get; set; }
        public string Block { get; set; }
        public string Section { get; set; }
        public string Lot { get; set; }
        public string Plan { get; set; }
        public string Elevation { get; set; }
        public string Legal { get; set; }
        public string GarageSwing { get; set; }
        public string LotStatus { get; set;}
     

    }

    public static class JobDataForLotFitRequests
    {
        public const string Id = "Id";
        public const string Title = "Title";
        public const string RegionCity = "Region_x002f_City";
        public const string Division = "Division";
        public const string Community = "Community";
        public const string Address = "Address";
        public const string JobNumber = "JobNumber";
        public const string Status = "Status";
        public const string Block = "Block";
        public const string Section = "Section";
        public const string Lot = "Lot";
        public const string Plan = "Plan";
        public const string Elevation = "Elevation";
        public const string Legal = "Legal";
        public const string GarageSwing = "GarageSwing";
        public const string LotStatus = "LotStatus";


    }
}
