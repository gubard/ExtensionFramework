﻿using System.Text;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class RandomStringCombine : IRandom<string>
{
    private readonly List<IRandom<string>> randoms;

    public RandomStringCombine(IEnumerable<IRandom<string>> randoms)
    {
        this.randoms = new (randoms.ThrowIfNull());
    }

    public string GetRandom()
    {
        var builder = new StringBuilder();

        foreach (var random in randoms)
        {
            var value = random.GetRandom();
            builder.Append(value);
        }

        return builder.ToString();
    }
}