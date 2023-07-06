﻿using ExtensionFramework.Core.Common.Helpers;
using ExtensionFramework.Core.Common.Interfaces;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.Common.Services;

public class RandomUInt64InInterval : IRandom<ulong, Interval<ulong>>
{
    public ulong GetRandom(Interval<ulong> options)
    {
        var value = CommonConstants.Random.Next((int)options.Min, (int)options.Max + 1);

        return (ulong)value;
    }
}