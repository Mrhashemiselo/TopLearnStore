using System.Globalization;

namespace TopLearn.Core.Convertors;
public static class DateConvertor
{
    public static string ToShamsi(this DateTime time)
    {
        PersianCalendar persianCalendar = new();
        return $"{persianCalendar.GetDayOfMonth(time).ToString("00")} / {persianCalendar.GetMonth(time).ToString("00")} / {persianCalendar.GetYear(time)}";
    }
}
