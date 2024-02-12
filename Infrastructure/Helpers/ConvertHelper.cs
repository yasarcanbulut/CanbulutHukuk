using System;
using System.Globalization;

namespace CanbulutHukuk.Infrastructure.Helpers
{
    public class ConvertHelper
    {
        public static string ToString(object value)
        {
            return string.IsNullOrWhiteSpace(value.ToString()) ? null : value.ToString();
        }

        public static string ToStringIfNullEmpty(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public static DateTime? ToNullableDateTime(object value)
        {
            return string.IsNullOrWhiteSpace(value.ToString()) ? null : (DateTime?)Convert.ToDateTime(value);
        }

        public static DateTime? ToNullableDateTimeFromSYSFormat(object value)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            DateTime date = new DateTime();
            if (DateTime.TryParseExact(Convert.ToString(value), "yyyyMMddHHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "dd.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "dd/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParseExact(Convert.ToString(value), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else if (DateTime.TryParse(Convert.ToString(value), out date))
                return date;

            return null;
        }

        public static string ToEnglishDateString(DateTime? value)
        {
            return value.Value.ToString("M.dd.yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToDateString(DateTime? value)
        {
            return value.Value.ToString("dd.M.yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToDateStringSysFormat(DateTime? value)
        {
            return value.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public static int? ToNullableInt32(object value)
        {
            return string.IsNullOrWhiteSpace(value.ToString()) ? null : (int?)Convert.ToInt32(value);
        }

        public static Int64 ToInt64(object value)
        {
            return Convert.ToInt64(value);
        }

        public static decimal? ToNullableDecimal(object value)
        {
            return string.IsNullOrWhiteSpace(value.ToString()) ? null : (decimal?)Convert.ToDecimal(value);
        }

        public static object IsNull(object value)
        {
            return string.IsNullOrWhiteSpace(Convert.ToString(value)) ? null : value;
        }

        public static bool IsNullOrEmpty(dynamic value)
        {
            return value == null || string.IsNullOrWhiteSpace(ToString(value.value));
        }
        public static string CheckNullableValue(dynamic data, string returnName)
        {
            return data != null ? ToString(data[returnName]) : string.Empty;
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
