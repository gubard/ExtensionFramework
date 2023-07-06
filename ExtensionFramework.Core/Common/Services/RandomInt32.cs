﻿using ExtensionFramework.Core.Common.Helpers;
using ExtensionFramework.Core.Common.Interfaces;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.Common.Services;

public class RandomInt32 : IRandom<int>
{
    private readonly Interval<int> interval;

    public RandomInt32(Interval<int> interval)
    {
        this.interval = interval;
    }

    public int GetRandom()
    {
        var value = CommonConstants.Random.Next(interval.Min, interval.Max + 1);

        return value;
    }
}