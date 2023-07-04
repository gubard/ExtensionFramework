using ExtensionFramework.Core.Common.Models;
using ExtensionFramework.Core.DependencyInjection.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface ILazyConfigurator
{
    void SetLazyOptions(TypeInformation type, LazyDependencyInjectorOptions options);
}