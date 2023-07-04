namespace ExtensionFramework.Core.Common.Interfaces;

public interface IDelay
{
    Task DelayAsync(TimeSpan delay);
}