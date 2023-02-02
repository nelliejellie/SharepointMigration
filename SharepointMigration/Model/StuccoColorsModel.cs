namespace SharePointMigration.Model
{
    public class StuccoColorsModel : ISiteModel
    {
        public string Id { get; set; }
        public string StuccoName { get; set; }
        public string StuccoColor { get; set; }
    }

    public static class StuccoColors
    {
        public const string Id = "Id";
        public const string StuccoName = "Title";
        public const string StuccoColor = "StuccoColor";
    }
}
