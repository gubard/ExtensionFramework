using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public readonly struct DelayService : IDelay
{
    public Task DelayAsync(TimeSpan delay)
    {
        return delay.Delay();
    }
}