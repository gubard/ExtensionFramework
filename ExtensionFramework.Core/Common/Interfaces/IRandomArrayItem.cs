﻿namespace ExtensionFramework.Core.Common.Interfaces;

public interface IRandomArrayItem<TValue>
{
    TValue? GetRandom(TValue[] values);
}