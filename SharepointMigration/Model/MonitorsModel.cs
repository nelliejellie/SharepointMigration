using System;

namespace SharePointMigration.Model
{
    public class MonitorsModel : ISiteModel
    {
        public string Id { get; set; }
        public string JobNumber { get; set; }
        public string DivisionName { get; set; }
        public string DivisionCityName { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StageOfConstruction { get; set; }
        public string PlanID { get; set; }
        public string Elevation { get; set; }
        public DateTime? PanelDate { get; set; }    
        public DateTime? EstimatedReleaseDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? LastReleaseDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? MonitorOneDate { get; set; }
        public DateTime? MonitorOneLetterDate { get; set; }
        public DateTime? MonitorOneLetterSignedDate { get; set; }
        public DateTime? MonitorTwoDate { get; set; }
        public DateTime? MonitorTwoLetterDate { get; set; }
        public DateTime? MonitorTwoLetterSignedDate { get; set; }
        public string PMEmail { get; set; }
        public string DPEmail { get; set; }
        public string VPCEmail { get; set; }
        public string Notes { get; set; }
        public string MonitorOneReviewer { get; set; }
        public string Skip { get; set; }
        public string SalesStatus { get; set; }
        public string RMOne { get; set; }
        public string RMTwo { get; set; }
        public string CPEmail { get; set; }
        public string MonitorStage { get; set; }
    }

    public static class Monitors
    {
        public const string Id = "Id";
        public const string JobNumber = "Title";
        public const string DivisionName = "Division_x0020_Name";
        public const string DivisionCityName = "Division_x0020_City_x0020_Name";
        public const string ProjectID = "Project_x0020_ID";
        public const string ProjectName = "Project_x0020_Name";
        public const string Address = "Address";
        public const string City = "City";
        public const string StageOfConstruction = "Stage_x0020_of_x0020_Constructio";
        public const string PlanID = "Plan_x0020_ID";
        public const string Elevation = "Elevation";
        public const string PanelDate = "Panel_x0020_Date";
        public const string EstimatedReleaseDate = "Estimated_x0020_Release_x0020_Da";
        public const string ReleaseDate = "Release_x0020_Date";
        public const string LastReleaseDate = "Last_x0020_Monitor_x0020_Date";
        public const string EstimatedCompletionDate = "Estimated_x0020_Completion_x0020";
        public const string PlanDate = "Plan_x0020_Date";
        public const string MonitorOneDate = "Monitor_x0020_I_x0020_Date";
        public const string MonitorOneLetterDate = "Monitor_x0020_I_x0020_Letter_x00";
        public const string MonitorOneLetterSignedDate = "Monitor_x0020_I_x0020_Letter_x000";
        public const string MonitorTwoDate = "Monitor_x0020_II_x0020_Date";
        public const string MonitorTwoLetterDate = "Monitor_x0020_II_x0020_Letter_x0";
        public const string MonitorTwoLetterSignedDate = "Monitor_x0020_II_x0020_Letter_x00";
        public const string PMEmail = "Project_x0020_Manager";
        public const string DPEmail = "DP_x0020_Email";
        public const string VPCEmail = "VPC_x0020_Email";
        public const string Notes = "Notes";
        public const string MonitorOneReviewer = "MonitorIReviewer";
        public const string Skip = "Skip";
        public const string SalesStatus = "Sales_x0020_Status";
        public const string RMOne = "_x0052_M1";
        public const string RMTwo = "_x0052_M2";
        public const string CPEmail = "CP_x0020_Email";
        public const string MonitorStage = "Monitor_x0020_Stage";
       

    }
}
