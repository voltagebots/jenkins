using System;
namespace GrocedyAPI.Helpers
{
    public static class DateTimeHelpers
    {
        

        public static string GetMonthNameYearDate(this string date) { 
            return $"{Convert.ToDateTime(date).ToString("MMMM")} {Convert.ToDateTime(date).Day} {Convert.ToDateTime(date).Year}";
        }
    }
}
