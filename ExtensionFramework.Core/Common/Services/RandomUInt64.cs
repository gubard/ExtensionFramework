﻿using ExtensionFramework.Core.Common.Interfaces;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.Common.Services;

public class RandomUInt64 : IRandom<ulong>
{
    private readonly Interval<ulong> interval;
    private readonly IRandom<ulong, Interval<ulong>> random;

    public RandomUInt64(IRandom<ulong, Interval<ulong>> random, Interval<ulong> interval)
    {
        this.random = random;
        this.interval = interval;
    }

    public ulong GetRandom()
    {
        return random.GetRandom(interval);
    }
}