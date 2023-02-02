namespace SharePointMigration.Model
{
    public class StuccoElevationsModel : ISiteModel
    {
        public string Id { get; set; }
        public string PHS { get; set;}
        public string Project { get; set; }
        public string Plan { get; set; }
        public string Elevation { get; set; }
        public string Swing { get; set; }
        public string Extra { get; set; }
        public string CostCode { get; set; }
        public string CT { get; set; }
        public string ItemNumber { get; set; }
        public string QTY { get; set; }
        public string GRP { get; set; }
        public string TYP { get; set; }
        public string LongDescription { get; set; }
        public string DFTREFPROJ { get; set; }
        public string ProjectStatus { get; set; }
        public string Estimator { get; set; }
        public string PlanGroup { get; set; }
        public string PlanGroupDescription { get; set; }
        public string Description { get; set; }
    }

    public static class StuccoElevations
    {
        public const string Id = "Id";
        public const string PHS = "Title";
        public const string Project = "PROJECT";
        public const string Plan = "PLAN";
        public const string Elevation = "ELEV";             
        public const string Swing = "SWING";
        public const string Extra = "EXTRA";
        public const string CostCode = "COST_x0020_CODE";
        public const string CT = "CT";
        public const string ItemNumber = "ITEM_x0020_NO_x002e_";
        public const string QTY = "QTY";
        public const string GRP = "GRP";
        public const string TYP = "TYP";
        public const string LongDescription = "LONG_x0020_DESCRIPTION";
        public const string DFTREFPROJ = "DFT_x0020_REF_x0020_PROJ";
        public const string ProjectStatus = "PROJECT_x0020_STATUS";
        public const string Estimator = "ESTIMATOR";
        public const string PlanGroup = "PLAN_x0020_GROUP";
        public const string PlanGroupDescription = "PLAN_x0020_GROUP_x0020_DESCRIPTI";
        public const string Description = "DESCRIPTION";





    }
}
