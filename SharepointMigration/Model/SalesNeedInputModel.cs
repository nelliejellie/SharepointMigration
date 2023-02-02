namespace SharePointMigration.Model
{
    public class SalesNeedInputModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectNumber { get; set; }
        public string Division { get; set; }
        public string Notes { get; set; }
        public string ProjectedUnits { get; set; }
        public string BudgetedUnits { get; set; }
        public string BudgetAvgSalesPrice { get; set; }
        public string BudgetCM { get; set; }
    }

    public static class SalesNeedInput
    {
        public const string Id = "Id";
        public const string ProjectTitle = "Title";
        public const string ProjectNumber = "Project_x0020_Number";
        public const string Division = "Division";
        public const string Notes = "Notes";
        public const string ProjectedUnits = "Projected_x0020_Units";
        public const string BudgetedUnits = "Budgeted_x0020_Units";
        public const string BudgetAvgSalesPrice = "Budget_x0020_Avg_x0020_Sales_x00";
        public const string BudgetCM = "Budget_x0020_C_x002e_M_x002e_";
    }
}
