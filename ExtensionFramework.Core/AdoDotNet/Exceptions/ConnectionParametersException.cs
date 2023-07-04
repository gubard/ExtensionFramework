using ExtensionFramework.Core.AdoDotNet.Extensions;
using ExtensionFramework.Core.AdoDotNet.Interfaces;

namespace ExtensionFramework.Core.AdoDotNet.Exceptions;

public class ConnectionParametersException<TConnectionParameters> : Exception
    where TConnectionParameters : IConnectionParameters
{
    public TConnectionParameters ConnectionParameters { get; }

    public ConnectionParametersException(
        TConnectionParameters connectionParameters,
        Exception inner
    )
        : base($"Exception in {connectionParameters.GetSafeConnectionString()}", inner)
    {
        ConnectionParameters = connectionParameters;
    }
}
