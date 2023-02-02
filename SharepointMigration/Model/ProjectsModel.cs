namespace SharePointMigration.Model
{
    public class ProjectsModel : ISiteModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string Market { get; set; }
        public string Brand { get; set; }
    }

    public static class Projects
    {
        public const string Id = "Id";
        public const string Title = "Title";
        public const string Number = "Number";
        public const string Market = "Market";
        public const string Brand = "Brand";
    }
}
