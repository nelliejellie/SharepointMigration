using System;

namespace SharePointMigration.Model
{
    public class PlanMenusModel : ISiteModel
    {
        public string Id { get; set; }
        public string PlanMenuId { get; set; }
        public string PlanMenuActive { get; set; }
        public string Phase { get; set; }
        public string PlanMenuDescription { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string LotBaseAmount { get; set; }
        public string PropertyMargin { get; set; }
        public string FooterNotes { get; set; }
        public string PhaseDescription { get; set; }
        public string PlanMenuLookup { get; set; }
    }

    public static class PlanMenus
    {
        public const string Id = "Id";
        public const string PlanMenuId = "Title";
        public const string PlanMenuActive = "PlanMenuActive";
        public const string Phase = "PHASE";
        public const string PlanMenuDescription = "PlanMenuDescription";
        public const string EffectiveDate = "EffectiveDate";
        public const string LotBaseAmount = "LotBaseAmount";
        public const string PropertyMargin = "PropertyMargin";
        public const string FooterNotes = "FooterNotes";
        public const string PhaseDescription = "PHASE_x003a_PhaseDescription";
        public const string PlanMenuLookup = "PlanMenuLookup";
    }
}
