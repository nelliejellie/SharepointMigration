using System;

namespace SharePointMigration.Model
{
    public class DesignCenterAppointmentsModel : ISiteModel
    {
        public string Id { get; set; }
        public string Homebuyer { get; set; }
        public string JobNumber { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string Plan { get; set; }
        public string SalesPerson { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? FirstAppt { get; set; }
        public DateTime? SecondAppt { get; set; }
        public DateTime? ThirdAppt { get; set; }
        public DateTime? HomeProAppt { get; set; }
        public string JobStatus { get; set; }
        public string ApptStatus { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? HProComplete { get; set; }
        public string HProC { get; set; }
        public string HProStatus { get; set; }
        public string Days { get; set; }
        public string Division { get; set; }
        public string DivPres { get; set; }
        public DateTime? CommentDate { get; set; }
        public string Comment { get; set; }
        public DateTime? MaxDate { get; set; }
        public string ApptStage { get; set; }
        public string HPDays { get; set; }



    }

    public static class DesignCenterAppointments
    {
        public const string Id = "Id";
        public const string Homebuyer = "Title";
        public const string JobNumber = "Job_x0020__x0023_";
        public const string Community = "Community";
        public const string Address = "Address";
        public const string Plan = "Plan";
        public const string SalesPerson = "Sales_x0020_Person";
        public const string ContractDate = "Contract_x0020_Date";
        public const string ReceiptDate = "Receipt_x0020_Date";
        public const string FirstAppt = "_x0031_st_x0020_Appt";
        public const string SecondAppt = "ak3g";
        public const string ThirdAppt = "wx4z";
        public const string HomeProAppt = "q88a";
        public const string JobStatus = "Job_x0020_Status";
        public const string ApptStatus = "Appt_x002e__x0020_Status";
        public const string CompletionDate = "Completion_x0020_Date";
        public const string HProComplete = "HomePro_x0020_Complete";
        public const string HProC = "HomePro_x0020__x0024_";
        public const string HProStatus = "HPro_x0020_Status";
        public const string Days = "Days";
        public const string Division = "Division";
        public const string DivPres = "Div_x0020_Pres";
        public const string CommentDate = "Comment_x0020_Date";
        public const string Comment = "Comment";
        public const string MaxDate = "DC_x0020_Max_x0020_Date";
        public const string ApptStage = "Appt_x0020_Stage";
        public const string HPDays = "HP_x0020_Days";


    }
}
