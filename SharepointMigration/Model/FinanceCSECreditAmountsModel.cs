namespace SharePointMigration.Model
{
    public class FinanceCSECreditAmountsModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectYear { get; set; }
        public string ProjectNumber { get; set; }
        public string January { get; set; }
        public string February { get; set; }
        public string March { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string June { get; set; }
        public string July { get; set; }
        public string August { get; set; }
        public string September { get; set; }
        public string October { get; set; }
        public string November { get; set; }
        public string December { get; set; }
    }

    public static class FinanceCSECreditAmounts
    {
        public const string Id = "Id";
        public const string ProjectYear = "ProjectYear";
        public const string ProjectNumber = "Title";
        public const string January = "January";
        public const string February = "February";
        public const string March = "March";
        public const string April = "April";
        public const string May = "May";
        public const string June = "June";
        public const string July = "July";
        public const string August = "August";
        public const string September = "September";
        public const string October = "October";
        public const string November = "November";
        public const string December = "December";
        
    }
}
