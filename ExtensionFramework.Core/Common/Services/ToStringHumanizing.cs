using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class ToStringHumanizing<TInput> : IHumanizing<TInput, string> where TInput : notnull
{
    public string Humanize(TInput input)
    {
        var result = input.ToString().ThrowIfNull();

        return result;
    }
}