namespace ExtensionFramework.Core.Common.Models;

public readonly struct WeeklyDayTime
{
    public WeeklyDayTime(DayOfWeek day, TimeOnly time)
    {
        Day = day;
        Time = time;
    }

    public DayOfWeek Day { get; }
    public TimeOnly Time { get; }
}