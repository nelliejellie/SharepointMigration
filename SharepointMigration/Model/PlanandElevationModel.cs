namespace SharePointMigration.Model
{
    public class PlanandElevationModel : ISiteModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Plan { get; set; }
        public string Elevation { get; set; }
        public string PlanStatus { get; set; }
        public string PlanKey { get; set; }
    }

    public static class PlanandElevation
    {
        public const string Id = "Id";
        public const string Title = "Title";
        public const string Plan = "Plan";
        public const string Elevation = "Elevation";
        public const string PlanStatus = "PlanStatus";
        public const string PlanKey = "PlanKey";
    }
}
