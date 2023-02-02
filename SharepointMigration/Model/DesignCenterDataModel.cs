using System;

namespace SharePointMigration.Model
{
    public class DesignCenterDataModel : ISiteModel
    {
        public string Id { get; set; }
        public string JobLookup { get; set; }
        public string UpgradeAmount { get; set; }
        public string AllowanceAmount { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceAmount { get; set; }
        public string InvoiceNotes { get; set; }
        public string Title { get; set; }
       
    }

    public static class DesignCenterData
    {
        public const string Id = "Id";
        public const string JobLookup = "Job_x0020_Lookup";
        public const string UpgradeAmount = "Upgrade_x0020_Amount";
        public const string AllowanceAmount = "Allowance_x0020_Amount";
        public const string InvoiceNumber = "Invoice_x0020__x0023_";
        public const string InvoiceDate = "Invoice_x0020_Date";
        public const string InvoiceAmount = "Invoice_x0020_Amount";
        public const string InvoiceNotes = "Invoice_x0020_Notes";
        public const string Title = "Title";
    }
}
