namespace SharePointMigration.Model
{
    public class ETCDatesPaidModel : ISiteModel
    {
        public string Id { get; set; }
        public string ClosingDate { get; set; }
        public string PaidDate { get; set; }
        public string CheckNumber { get; set; }
    }

    public static class ETCDatesPaid
    {
        public const string Id = "Id";
        public const string ClosingDate = "Title";
        public const string PaidDate = "PaidDate";
        public const string CheckNumber = "CheckNumber";
    }
}
