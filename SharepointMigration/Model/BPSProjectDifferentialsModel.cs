namespace SharePointMigration.Model
{
    public class BPSProjectDifferentialsModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectNumber { get; set; }
        public string DivisionName { get; set; }
        public string ProjectSort { get; set; }
        public string Phase { get; set; }
        public string RatePlan { get; set; }
        public string PropertyMargin { get; set; }
        public string FieldMargin { get; set; }
        public string MinMargin { get; set; }
        public string BaseMargin { get; set; }
        public string MinimumPlanSqFt { get; set; }
        public string MMaximumPlanSqFt { get; set; }
        public string LotBaseAmount { get; set; }
        public string LotBasePrepAmount { get; set; }
        public string LotOtherAmount { get; set; }
        public string LotOtherPercentage { get; set; }
        public string AmountOffSalesPrice { get; set; }
        public string PercentageOffSalePrice { get; set; }
        public string OneStoryAmount { get; set; }
        public string TwoStoryAmount { get; set; }
        public string DetachedGarageAmount { get; set; }
        public string FSAGarageAmount { get; set; }
        public string LotSize { get; set; }
        public string LegalNotice { get; set; }
        
    }

    public static class BPSProjectDifferential
    {
        public const string Id = "Id";
        public const string ProjectNumber = "Title";
        public const string DivisionName = "DivisionName";
        public const string ProjectSort = "ProjectSort";
        public const string Phase = "Phase";
        public const string RatePlan = "RatePlan";
        public const string FieldMargin = "FieldMargin";
        public const string MinMarginn = "MinMargin";
        public const string BaseMargin = "BaseMargin";
        public const string MinimumPlanSqFt = "MinimumPlanSqFt";
        public const string MMaximumPlanSqFt = "MaximumPlanSqFt";
        public const string LotBaseAmount = "Lot_x0020_Base_x0020_Amount";
        public const string LotBasePrepAmount = "Lot_x0020_Base_x0020_Prep_x0020_";
        public const string LotOtherAmount = "LotOtherAmount";
        public const string LotOtherPercentage = "LotOtherPercentage";
        public const string AmountOffSalesPrice = "AmountOffSalesPrice";
        public const string PercentageOffSalePrice = "PercentageOffSalePrice";
        public const string OneStoryAmount = "OneStoryAmount";
        public const string TwoStoryAmountt = "TwoStoryAmount";
        public const string DetachedGarageAmountt = "DetachedGarageAmount";
        public const string FSAGarageAmount = "FSAGarageAmount";
        public const string LotSize = "LotSize";
        public const string LegalNotice = "LegalNotice";
    }
}