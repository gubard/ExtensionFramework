namespace ExtensionFramework.Core.Common.Models;

public readonly struct YearDateTime
{
    public YearDateTime(byte month, byte day, TimeOnly time)
    {
        Month = month;
        Day = day;
        Time = time;
    }

    public byte Month { get; }
    public byte Day { get; }
    public TimeOnly Time { get; }
}