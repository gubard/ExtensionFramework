using ExtensionFramework.Core.Common.Helpers;
using ExtensionFramework.Core.Common.Interfaces;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.Common.Services;

public class RandomUInt16InInterval : IRandom<ushort, Interval<ushort>>
{
    public ushort GetRandom(Interval<ushort> options)
    {
        var value = CommonConstants.Random.Next(options.Min, options.Max + 1);

        return (ushort)value;
    }
}