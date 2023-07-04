using ExtensionFramework.Core.ModularSystem.Interfaces;
using ReactiveUI;
using Splat;

namespace ExtensionFramework.ReactiveUI.Services;

public class ReactiveUIModuleSetup : IModuleSetup
{
    public void Setup(IViewLocator viewLocator)
    {
        Locator.CurrentMutable.RegisterLazySingleton(() => viewLocator, typeof(IViewLocator));
    }
}