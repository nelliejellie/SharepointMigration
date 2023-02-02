using System;

namespace SharePointMigration.Model
{
    public class LotInventoryBankholidaysModel : ISiteModel
    {
        public string Id { get; set; }  
        public string HolidayYear { get; set; }
        public DateTime? HolidayDate { get; set; }  
    }

    public static class LotInventoryBankholidays
    {
        public const string Id = "Id";
        public const string HolidayYear = "Title";
        public const string HolidayDate = "HolidayDate";
    }
}
