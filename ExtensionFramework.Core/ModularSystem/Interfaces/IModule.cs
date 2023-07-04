using ExtensionFramework.Core.Common.Models;
using ExtensionFramework.Core.DependencyInjection.Interfaces;

namespace ExtensionFramework.Core.ModularSystem.Interfaces;

public interface IModule : IDependencyStatusGetter
{
    Guid Id { get; }
    ReadOnlyMemory<TypeInformation> Inputs { get; }
    ReadOnlyMemory<TypeInformation> Outputs { get; }

    object GetObject(TypeInformation type);
}