using ExtensionFramework.Core.AdoDotNet.Models;

namespace ExtensionFramework.Core.AdoDotNet.Interfaces;

public interface IConnectionParameters
{
    IEnumerable<ConnectionParameter> Parameters { get; }
    IEnumerable<ConnectionParameter> SafeParameters { get; }
}
