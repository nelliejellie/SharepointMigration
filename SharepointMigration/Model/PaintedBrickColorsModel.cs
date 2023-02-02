namespace SharePointMigration.Model
{
    public class PaintedBrickColorsModel : ISiteModel
    {
        public string Id { get; set; }
        public string PaintedBrickName { get; set; }
        public string PaintedBrickColor { get; set; }
    }

    public static class PaintedBrickColors
    {
        public const string Id = "Id";
        public const string PaintedBrickName = "Title";
        public const string PaintedBrickColor = "PaintedBrickColor";
    }
}
