using Newtonsoft.Json;
using SharePointMigration.Helper;
using System;

namespace SharePointMigration.Model
{
    public class ExteriorandInteriorSelectionsModel : ISiteModel
    {
        public string Id { get; set; }
        public string Job { get; set; }
       // public string Community { get; set; }
        public string Address { get; set; }
       // public string PanelDate { get; set; }
      
      //public DateTime? ExtPostDate { get; set; }
       
        //public DateTime? ReleaseDate { get; set; }
        public string ProjectNumber { get; set; }
        public string Plan { get; set; }
        public string Elevation { get; set; }
       
       // public DateTime? InputDate { get; set; }
        //public string JobPanelStatus { get; set; }
       // public string ReleaseCoordinator { get; set; }
       // public string SelectionType { get; set; }
      
        //public DateTime? DeveloperSentDate { get; set; }
        //public string ExtSelectionApprovedbyDeveloper { get; set; }
      
        //public DateTime? DeveloperApprovalDate { get; set; }
        //public string DeveloperApprovalStatus { get; set; }
      
        //public DateTime? ExtSelectionPostedtoBuzzsaw { get; set; }
        //public string ExtSelectionDelayed { get; set; }
        //public string ReasonforDelay { get; set; }
        //public string AdditionalInformation { get; set; }
       
        public string? DateSold { get; set; }
        //public string LateDuetoDeveloper { get; set; }
        //public string TypeofExperiment { get; set; }
        //public string ExtSelectionsComments { get; set; }
        //public string ExtCoor { get; set; }
        //public string IntCoor { get; set; }
          public string LotStatus { get; set; }
        //public string IntSelectionDelayed { get; set; }
        //public string IntSelectionComments { get; set; }
      
        //public DateTime? SepecApprovedDate { get; set; }
      
        //public DateTime? ExtSentToRC { get; set; }
      
        //public DateTime? IntSentToRC { get; set; }
      
        //public DateTime? IntPostDate { get; set; }
        //public string ExtCoordinator { get; set; }
        //public string IntCoordinator { get; set; }
      
        //public DateTime? DateNHSSentEmailToSelections { get; set; }
      
        //public DateTime? RCRequestSentToExt { get; set; }
        //public string TwoHundredCompleted { get; set; }
      
        //public DateTime? TwoHunderedCompDate { get; set; }
        //public string TwoHundredDelayReason { get; set; }
        //public string TwoHundredTwentyCompleted { get; set; }
      
        //public DateTime? TwoHundredTwentyCompDate { get; set; }
        //public string TwoHundredTwentyDelayReason { get; set; }
        //public string TwoHundredThiryCompleted { get; set; }
      
        //public DateTime? TwoHundredThirtyCompDate { get; set; }
        //public string TwoHundredThirtyDelayReason { get; set; }
        //public string TwoHundredFiftyCompleted { get; set; }
      
        //public DateTime? TwoHundredFiftyCompDate { get; set; }
        //public string TwoHundredFiftyDelayReason { get; set; }
        //public string Division { get; set; }
          public string City { get; set; }
        //public string Estimator { get; set; }
        //public string POAmdministrator { get; set; }
        //public string NotesPOA { get; set; }


    }

    public static class ExteriorandInteriorSelections
    {
        public const string Id = "Id";
        public const string Job = "Title";
        public const string Community = "Community";
        public const string Address = "Address";
        public const string PanelDate = "Panel_x0020_Date";
        public const string ExtPostDate = "Ex_x002e__x0020_Selection_x0020_0";
        public const string ReleaseDate = "Release_x0020_Date";
        public const string ProjectNumber = "Project_x0020_Number";
        public const string Plan = "Plan";
        public const string Elevation = "Elevation";
        public const string InputDate = "Input_x0020_Date";
        public const string JobPanelStatus = "Job_x0020_Panel_x0020_Status";
        public const string ReleaseCoordinator = "Release_x0020_Coordinator";
        public const string SelectionType = "Selection_x0020_Type";
        public const string DeveloperSentDate = "Ex_x002e__x0020_Selection_x0020_1";
        public const string ExtSelectionApprovedbyDeveloper = "Ex_x002e__x0020_Selection_x0020_";
        public const string DeveloperApprovalDate = "Developer_x0020_Approval_x0020_D";
        public const string DeveloperApprovalStatus = "Developer_x0020_Approval_x0020_S";
        public const string ExtSelectionPostedtoBuzzsaw = "Ex_x002e__x0020_Selection_x0020_2";
        public const string ExtSelectionDelayed = "Selection_x0020_Delayed";
        public const string ReasonforDelay = "Reason_x0020_for_x0020_Delay";
        public const string AdditionalInformation = "Additional_x0020_Information";
        public const string DateSold = "Date_x0020_Sold";
        public const string LateDuetoDeveloper = "Late_x0020_Due_x0020_To_x0020_De";
        public const string TypeofExperiment = "Type_x0020_Of_x0020_Experiment";
        public const string ExtSelectionsComments = "Selection_x0020_Comments";
        public const string ExtCoor = "Exterior_x0020_Cordinator";
        public const string IntCoor = "Interior_x0020_Cordinator";
         public const string LotStatus = "Lot_x0020_Status";
        public const string IntSelectionDelayed = "Interior_x0020_Selection_x0020_D";
        public const string IntSelectionComments = "Int_x002e__x0020_Selection_x0020";
        public const string SepecApprovedDate = "Spec_x0020_Approved_x0020_Date";
        public const string ExtSentToRC = "Ext_x002e__x0020_Sent_x0020_to_x";
        public const string IntSentToRC = "Int_x002e__x0020_Sent_x0020_to_x";
        public const string IntPostDate = "Int_x002e__x0020_Post_x0020_Date";
        public const string ExtCoordinator = "Exterior_x0020_Coordinator";
        public const string IntCoordinator = "Interior_x0020_Cordinator0";
        public const string DateNHSSentEmailToSelections = "Date_x0020_NHS_x0020_sent_x0020_";
        public const string RCRequestSentToExt = "RC_x0020_Request_x0020_sent_x002";
        public const string TwoHundredCompleted = "_x0032_00_x0020_Completed";
        public const string TwoHunderedCompDate = "_x0032_00_x0020_Comp_x002e__x002";
        public const string TwoHundredDelayReason = "Reason_x0020_Delay_x0020_200";
        public const string TwoHundredTwentyCompleted = "_x0032_20_x0020_Completed";
        public const string TwoHundredTwentyCompDate = "_x0032_20_x0020_Comp_x002e__x002";
        public const string TwoHundredTwentyDelayReason = "_x0032_20_x0020_Delay_x0020_Reas";
        public const string TwoHundredThiryCompleted = "_x0032_30_x0020__x0026__x0020_24";
        public const string TwoHundredThirtyCompDate = "_x0032_30_x0020__x0026__x0020_240";
        public const string TwoHundredThirtyDelayReason = "Reason_x0020_Delay_x0020_230_x00";
        public const string TwoHundredFiftyCompleted = "_x0032_50_x0020__x0026__x0020_26";
        public const string TwoHundredFiftyCompDate = "_x0032_50_x0020__x0026__x0020_260";
        public const string TwoHundredFiftyDelayReason = "_x0032_50_x0020__x0026__x0020_261";
        public const string Division = "Division";
        public const string City = "City";
        public const string Estimator = "Estimator";
        public const string POAmdministrator = "POAdministrator";
        public const string NotesPOA = "Notes_x0020__x002d__x0020_POAs";

    }
}
