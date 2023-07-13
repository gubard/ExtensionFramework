namespace ExtensionFramework.Core.Common.Models;

public readonly struct MonthDayTime
{
    public MonthDayTime(byte day, TimeOnly time)
    {
        Day = day;
        Time = time;
    }

    public byte Day { get; }
    public TimeOnly Time { get; }
}