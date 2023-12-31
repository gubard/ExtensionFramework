﻿namespace ExtensionFramework.Core.Common.Interfaces;

public interface IHumanizing<in TInput, out TOutput> where TInput : notnull
{
    TOutput Humanize(TInput input);
}