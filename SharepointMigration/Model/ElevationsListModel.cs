namespace SharePointMigration.Model
{
    public class ElevationsListModel : ISiteModel
    {
        public string Id { get; set; }
        public string PlanId { get; set; }
        public string Elevation { get; set; }
        public string PlanMenu { get; set; }
        public string PlanStatus { get; set; }
        public string ElevationStatus { get; set; }
        public string PlanSqFt { get; set; }
        public string Stories { get; set; }
        public string Releases { get; set; }
    }

    public static class ElevationsList
    {
        public const string Id  = "Id";
        public const string PlanId = "Title";
        public const string Elevation = "ELEVATION";
        public const string PlanMenu = "PLAN_x0020_MENU";
        public const string PlanStatus = "PLAN_x0020_STATUS";
        public const string ElevationStatus = "ELEVATION_x0020_STATUS";
        public const string PlanSqFt = "PLAN_x0020_SQ_x0020_FT0";
        public const string Stories = "STORIES";
        public const string Releases = "RELEASES";
    }
}
