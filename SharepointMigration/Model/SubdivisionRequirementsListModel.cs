namespace SharePointMigration.Model
{
    public class SubdivisionRequirementsListModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectNumber { get; set; }
        public string ReleaseCoordinator { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
        public string Community { get; set; }
        public string Active { get; set; }
        public string SelectionType { get; set; }
        public string PermittingJurisdiction { get; set; }
        public string MainConstructionContact { get; set; }
        public string DeveloperContactInformation { get; set; }
        public string DeveloperSubmittalRequirements { get; set; }
        public string SitePlanReviewFee { get; set; }
        public string StiePlanReviewFeeCost { get; set; }
        public string MasterPlanReviewFee { get; set; }
        public string MasterPlanReviewCost { get; set; }
        public string PermitContactInformation { get; set; }
        public string PermitsSubmittalRequirements { get; set; }
        public string Permit { get; set; }
        public string CountyPermitCost { get; set; }
        public string DeveloperApproval { get; set; }
        public string PermitExpiration { get; set; }
        public string FoundationNotes { get; set; }
        public string EnergyPerformanceCheck { get; set; }
        public string SitePlan { get; set; }
        public string ManualJ { get; set; }
        public string Foundation { get; set; }
        public string Norex { get; set; }
        public string Landscape { get; set; }
        public string OtherWights { get; set; }
        public string AdditionalInformation { get; set; }
        public string SubdivisionReviewedandApproved { get; set; }
        public string CommunityLotsDontNeedPurchased { get; set; }
        public string OpenCommunities { get; set; }
        public string DeveloperApprovalRequiredforPermit { get; set; }
        public string ProjectManager { get; set; }
        public string Clusters { get; set; }
        public string DeveloperSelections { get; set; }
        public string NeedsReview { get; set; }
        public string ReleaseWeightPoints { get; set; }
        
    }

    public static class SubdivisionRequirementsList
    {
        public const string Id = "Id";
        public const string ProjectNumber = "Title";
        public const string ReleaseCoordinator = "Release_x0020_Coordinator";
        public const string Region = "Region";
        public const string Division = "Division";
        public const string Community = "Community";
        public const string Active = "Active";
        public const string SelectionType = "Selection_x0020_Type";
        public const string PermittingJurisdiction = "Permitting_x0020_Jurisdiction";
        public const string MainConstructionContact = "Main_x0020_Construction_x0020_Co";
        public const string DeveloperContactInformation = "Developer_x0020_Contact_x0020_In";
        public const string DeveloperSubmittalRequirements = "Developer_x0020_Submittal_x0020_";
        public const string SitePlanReviewFee = "Plan_x0020_Review_x0020_Fee";
        public const string StiePlanReviewFeeCost = "Plan_x0020_Review_x0020_Fee_x002";
        public const string MasterPlanReviewFee = "Master_x0020_Plan_x0020_Review_x";
        public const string MasterPlanReviewCost = "Master_x0020_Plan_x0020_Review_x0";
        public const string PermitContactInformation = "Permit_x0020_Contact_x0020_Infor";
        public const string PermitsSubmittalRequirements = "Permits_x0020_Submittal_x0020_Re";
        public const string Permit = "Permit";
        public const string CountyPermitCost = "County_x0020_Permit_x0020_Cost";
        public const string DeveloperApproval = "Developer_x0020_Approval_x0020_B";
        public const string PermitExpiration = "Permit_x0020_Expiration";
        public const string FoundationNotes = "Foundation_x0020_notes";
        public const string EnergyPerformanceCheck = "%7BF4EE76DD-0781-4B51-A5D0-B619950F9791%7D&Field=REScheck";
        public const string SitePlan = "Site_x0020_Plan";
        public const string ManualJ = "Manual_x0020_J";
        public const string Foundation = "Strand_x0020_Slab";
        public const string Norex = "Norex";
        public const string Landscape = "Landscape";
        public const string OtherWights = "Other_x0020_Weights";
        public const string AdditionalInformation = "Additional_x0020_Information";
        public const string SubdivisionReviewedandApproved = "Community_x0020_Reviewed_x0020__";
        public const string CommunityLotsDontNeedPurchased = "Perry_x0020_Developed_x0020_Comm";
        public const string OpenCommunities = "Open_x0020_Communities";
        public const string DeveloperApprovalRequiredforPermit = "";
        public const string ProjectManager = "Developer_x0020_Approval_x0020_R";
        public const string Clusters = "Project_x0020_Manager";
        public const string DeveloperSelections = "Clusters";
        public const string NeedsReview = "Developer_x0020_Selections";
        public const string ReleaseWeightPoints = "Release_x0020_Weight_x0020_Point";

    }
}
