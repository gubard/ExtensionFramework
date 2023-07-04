using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IDependencyInjector : IResolver, IInvoker, IDependencyStatusGetter
{
    ReadOnlyMemory<TypeInformation> Inputs { get; }
    ReadOnlyMemory<TypeInformation> Outputs { get; }
}