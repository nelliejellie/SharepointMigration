namespace SharePointMigration.Model
{
    public class EstimatorDetailsModel : ISiteModel
    {
        public string Id { get; set; }
        public string EstimatorName { get; set; }
        public string EstimatorEmailAddress { get; set; }
    }

    public static class EstimatorDetails
    {
        public const string Id = "Id";
        public const string EstimatorName = "Title";
        public const string EstimatorEmailAddress = "EstimatorEmailAddress";
    }
}
