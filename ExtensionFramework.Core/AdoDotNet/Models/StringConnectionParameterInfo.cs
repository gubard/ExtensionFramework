namespace ExtensionFramework.Core.AdoDotNet.Models;

public record StringConnectionParameterInfo : ConnectionParameterInfo
{
    public StringConnectionParameterInfo(
        string defaultAlias,
        IEnumerable<string> aliases,
        string defaultValue
    )
        : base(defaultAlias, aliases, defaultValue) { }
}
