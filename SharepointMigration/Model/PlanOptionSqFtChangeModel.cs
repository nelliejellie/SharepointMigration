namespace SharePointMigration.Model
{
    public class PlanOptionSqFtChangeModel : ISiteModel
    {
        public string Id { get; set; }
        public string Plan { get; set; }
        public string PlanElevation { get; set; }
        public string CombinationGroup { get; set; }
        public string OptionCode { get; set; }
        public string IsActive { get; set; }
        public string SquareFootageChange { get; set; }
        public string Garage { get; set; }
        public string Stories { get; set; }
        public string Bedrooms { get; set; }
        public string Bathroom { get; set; }
        public string HalfBath { get; set; }
        public string Library { get; set; }
        public string Media { get; set; }
        public string GameRoom { get; set; }
        public string DuplicateSqFtPlanMenu { get; set; }
        public string IncludeSqFtPlanMenu { get; set; }
    }

    public static class PlanOptionsSqFtChange
    {
        public const string Id = "Id";
        public const string Plan = "Title";
        public const string PlanElevation = "PlanElevation";
        public const string CombinationGroup = "CombinationGroup";
        public const string OptionCode = "OptionCode";
        public const string IsActive = "IsActive";
        public const string SquareFootageChange = "SquareFootageChange";
        public const string Garage = "Garage";
        public const string Stories = "Stories";
        public const string Bedrooms = "Bedrooms";
        public const string Bathroom = "Bathroom";
        public const string HalfBath = "HalfBath";
        public const string Library = "Library";
        public const string Media = "Media";
        public const string GameRoom = "GameRoom";
        public const string DuplicateSqFtPlanMenu = "DuplicatePmOption";
        public const string IncludeSqFtPlanMenu = "ncludeSqFtPlanMenu";
    }
}
