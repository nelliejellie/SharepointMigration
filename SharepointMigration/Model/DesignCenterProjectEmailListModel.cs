namespace SharePointMigration.Model
{
    public class DesignCenterProjectEmailListModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectNumber { get; set; }
        public string DivisionText { get; set; }
        public string Email { get; set; }
       
    }

    public static class DesignCenterProjectEmailList
    {
        public const string Id = "Id";
        public const string ProjectTitle = "Title";
        public const string ProjectNumber = "ProjectNumber";
        public const string DivisionText = "Division_x0020_Text";
        public const string Email = "Email";
    }
}
