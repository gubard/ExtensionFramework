﻿using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.AdoDotNet.Models;

namespace ExtensionFramework.Core.AdoDotNet.Extensions;

public static class ConnectionParameterExtension
{
    public static bool IsDefault(this ConnectionParameter parameter)
    {
        return parameter.ParameterValue.Value == parameter.Info.DefaultValue;
    }

    public static string AsString(this ConnectionParameter parameter)
    {
        return $"{parameter.Info.DefaultAlias}={parameter.ParameterValue.Value}";
    }

    public static IEnumerable<ConnectionParameter> GetNoDefaultParameters(
        this IEnumerable<ConnectionParameter> parameters
    )
    {
        return parameters.Where(x => x.IsDefault().IsFalse());
    }

    public static string GetConnectionString(this IEnumerable<ConnectionParameter> parameters)
    {
        return parameters.Select(x => x.AsString()).JoinString(";");
    }
}
