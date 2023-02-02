using System;

namespace SharePointMigration.Model
{
    public class CompletedRequestsModel : ISiteModel
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string ApproveRejectComments { get; set; }
        public string AudienceTargeting { get; set; }
        public string Buyer { get; set; }
        public string BuyerID { get; set; }
        public string Category { get; set; }
        public string Community { get; set; }
        public string DateRequested { get; set; }
        public string Description { get; set; }
        public string DesignAssignedTo { get; set; }
        public string DesignCompletionDate { get; set; }
        public string DesignFinishDate { get; set; }
        public string Division { get; set; }
        public string DivisionPresident { get; set; }
        public string DP { get; set; }
        public string DPApprovalDate { get; set; }
        public string DPApprovalStatus { get; set; }
        public string DPApprovalStatusBefore { get; set; }
        public DateTime? DPApprovedDate { get; set; }
        public string DPComments { get; set; }
        public string DPRejectedDate { get; set; }
        public DateTime? DPRejectDate { get; set; }
        public string EditItem { get; set; }
        public string ItemID { get; set; }
        public string JobNumber { get; set; }
        public string OptionsComments { get; set; }
        public string PlanElevation { get; set; }
        public string PlanRevision { get; set; }
        public string PlanRevisionBefore { get; set; }
        public string PlanRevisionType { get; set; }
        public string PricingAssignedTo { get; set; }
        public string PricingCompleteStatusBefore { get; set; }
        public string PricingCompleted { get; set; }
        public string PricingCompletionDate { get; set; }
        public string PricingDocument { get; set; }
        public DateTime? PricingFinishDate { get; set; }
        public string PricingNeeded { get; set; }
        public string RequestAssignedTo { get; set; }
        public string RequestAssignedToBefore { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestStatus { get; set; }
        public string RequestStatusBefore { get; set; }
        public string SalesPrice { get; set; }
        public string SentEmail { get; set; }
        public string SketchCompleteValueBefore { get; set; }
        public string SketchesCompleted { get; set; }
        public string SketchesNeeded { get; set; }
        public string StageOfContruction { get; set; }
        public string Status { get; set; }
        public string StausBefore { get; set; }
        public string StatusComplete { get; set; }
        public string TargetAudiences { get; set; }
        public string Title { get; set; }
        public string VPC { get; set; }
        public string VPCComments { get; set; }
        public string VPCPerson { get; set; }

    }

    public static class CompletedRequests
    {
        public const string Id = "Id";
        public const string Address = "Address";
        public const string Community = "Community";
        public const string ApproveRejectComments = "Approve_x002f_Reject_x0020_Comme";
        public const string AudienceTargeting = "Target_x0020_Audiences";
        public const string Buyer = "Buyer0";
        public const string BuyerID = "Buyer";
        public const string Category = "Category";
        public const string Description = "Description";
        public const string DateRequested = "RequestDate";
        public const string DesignAssignedTo = "Design_x0020_Assigned_x0020_To";
        public const string DesignCompletionDate = "Design_x0020_Completion_x0020_Da";
        public const string DesignFinishDate = "Design_x0020_Finish_x0020_Date";
        public const string Division = "Division";
        public const string DivisionPresident = "Division_x0020_President";
        public const string DP = "DP";
        public const string DPApprovalDate = "DP_x0020_Approval_x0020_Date";
        public const string DPApprovalStatus = "DP_x0020_Approval_x0020_Status";
        public const string DPApprovalStatusBefore = "DP_x0020_Approval_x0020_Status_x";
        public const string DPApprovedDate = "DP_x0020_Approved_x0020_Date";
        public const string DPComments = "r49r";
        public const string DPRejectedDate = "Date_x0020_Rejected_x0020_Date";
        public const string DPRejectDate = "DP_x0020_Reject_x0020_Date";
        public const string EditItem = "Edit_x0020_Item";
        public const string ItemID = "ItemID";
        public const string JobNumber = "Job_x0020_Number";
        public const string OptionsComments = "nk5v";
        public const string PlanElevation = "Plan_x0020__x0026__x0020_Elevati";
        public const string PlanRevision = "Plan_x0020_Revision";
        public const string PlanRevisionBefore = "Plan_x0020_Revision_x0020_Before";
        public const string PlanRevisionType = "Plan_x0020_Revision_x0020_Type";
        public const string PricingAssignedTo = "Pricing_x0020_Assigned_x0020_To";
        public const string PricingCompleteStatusBefore = "Pricing_x0020_Complete_x0020_Sta";
        public const string PricingCompleted = "Pricing_x0020_Completed";
        public const string PricingCompletionDate = "Pricing_x0020_Completion_x0020_D";
        public const string PricingDocument = "Pricing_x0020_Document";
        public const string PricingFinishDate = "Pricing_x0020_Finish_x0020_Date";
        public const string PricingNeeded = "Pricing_x0020_Needed";
        public const string RequestAssignedTo = "Request_x0020_Assigned_x0020_To";
        public const string RequestAssignedToBefore = "Request_x0020_Assigned_x0020_to_";
        public const string RequestDate = "Request_x0020_Date";
        public const string RequestStatus = "Request_x0020_Status";
        public const string RequestStatusBefore = "Request_x0020_Status_x0020_Befor";
        public const string SalesPrice = "Sales_x0020_Price";
        public const string SentEmail = "Sent_x0020_Email";
        public const string SketchCompleteValueBefore = "Sketch_x0020_Complete_x0020_Valu";
        public const string SketchesCompleted = "Sketches_x0020_Completed";
        public const string SketchesNeeded = "Sketches_x0020_Needed";
        public const string StageOfContruction = "Stage_x0020_Of_x0020_Constructio";
        public const string Status = "Status";
        public const string StausBefore = "Status_x0020_Before";
        public const string StatusComplete = "Status_x0020_Complete";
        public const string TargetAudiences = "Target_x0020_Audiences";
        public const string Title = "Title";
        public const string VPC = "VPC";
        public const string VPCComments = "VPC_x0020_Comments";
        public const string VPCPerson = "VPC_x0020_Person";



    }
}
