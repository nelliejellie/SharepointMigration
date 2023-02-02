using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointMigration.Model
{
    public class SubdivisionSelectionTypeModel : ISiteModel
    {
        public string Id { get; set; }
        public string ProjectNumber { get; set; }
        public string Community { get; set; }
        public string Active { get; set; }
    }


    public static class SubdivisionSelectionType
    {
        public const string Id = "Id";
        public const string ProjectNumber = "Title";
        public const string Community = "Community";
        public const string Active = "Active";
    }

}
