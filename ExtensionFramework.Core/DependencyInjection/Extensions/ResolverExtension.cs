﻿using ExtensionFramework.Core.DependencyInjection.Interfaces;

namespace ExtensionFramework.Core.DependencyInjection.Extensions;

public static class ResolverExtension
{
    public static TObject Resolve<TObject>(this IResolver resolver)
        where TObject : notnull
    {
        var type = typeof(TObject);

        return (TObject)resolver.Resolve(type);
    }
}