﻿using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public readonly struct RandomGuid : IRandom<Guid>
{
    public static readonly RandomGuid Default = new();

    public Guid GetRandom()
    {
        return Guid.NewGuid();
    }
}