namespace SharePointMigration.Model
{
    public class BrickColorsModel : ISiteModel
    {
        public string Id { get; set; }
        public string BrickSelection { get; set; }
        public string BrickColorGroup { get; set; }
        public string BrickColorGroupDallas { get; set; }
        
    }

    public static class BrickColors
    {
        public const string Id = "Id";
        public const string BrickSelection = "Title";
        public const string BrickColorGroup = "Brick_x0020_Color";
        public const string BrickColorGroupDallas = "BrickColorDallas";
   }
}
