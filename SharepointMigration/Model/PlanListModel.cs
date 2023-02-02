namespace SharePointMigration.Model
{
    public class PlanListModel : ISiteModel
    {
        public string Id  { get; set; }
        public string PlanID { get; set; }
        public string PlanMenu { get; set; }
        public string PlanStatus { get; set; }
        public string Releases { get; set; }
        public string PlanSqFt { get; set; }
        public string Stories { get; set; }
    }

    public static class PlanList
    {
        public const string Id = "Id";
        public const string PlanID = "Title";
        public const string PlanMenu = "PLAN_x0020_MENU";
        public const string PlanStatus = "PLAN_x0020_STATUS";
        public const string Releases = "RELEASES";
        public const string PlanSqFt = "PLAN_x0020_SQ_x0020_FT";
        public const string Stories = "STORIES";
    }
}
