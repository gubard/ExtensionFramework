using ExtensionFramework.Core.Common.Models;
using ExtensionFramework.Core.DependencyInjection.Exceptions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.DependencyInjection.Models;
using ExtensionFramework.Core.ModularSystem.Interfaces;

namespace ExtensionFramework.Core.ModularSystem.Services;

public class Module : IModule
{
    private readonly IDependencyInjector dependencyInjector;

    public Module(Guid id, IDependencyInjector dependencyInjector)
    {
        this.dependencyInjector = dependencyInjector;
        Id = id;
    }

    public Guid Id { get; }
    public ReadOnlyMemory<TypeInformation> Inputs => dependencyInjector.Inputs;
    public ReadOnlyMemory<TypeInformation> Outputs => dependencyInjector.Outputs;

    public object GetObject(TypeInformation type)
    {
        if (!Outputs.Span.Contains(type))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        return dependencyInjector.Resolve(type);
    }

    public DependencyStatus GetStatus(
        TypeInformation type,
        Dictionary<TypeInformation, ScopeValue> scopeParameters
    )
    {
        var status = dependencyInjector.GetStatus(type, scopeParameters);

        return status;
    }
}