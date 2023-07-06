namespace ExtensionFramework.Core.Common.Extensions;

public static class DateTimeOffsetExtension
{
    public static DateTimeOffset ToCurrentDay(this DateTimeOffset date)
    {
        var result = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);

        return result;
    }
    
    public static DateTimeOffset? ToCurrentDayOrNull(this DateTimeOffset? date)
    {
        if (date is null)
        {
            return null;
        }

        return date.Value.ToCurrentDay();
    }
}