namespace SharePointMigration.Model
{
    public class LotInventoryDeveloperListModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectNumber { get; set; }
        public string ContactName { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }


    }

    public static class LotInventoryDeveloperList
    {
        public const string Id = "Id";
        public const string ProjectNumber = "Title";
        public const string ContactName = "ContactName";
        public const string FaxNumber = "FaxNumber";
        public const string EmailAddress = "EmailAddress";
    }
}
