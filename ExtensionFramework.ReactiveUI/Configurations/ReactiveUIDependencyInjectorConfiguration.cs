using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.DependencyInjection.Extensions;
using ExtensionFramework.Core.ModularSystem.Interfaces;
using ExtensionFramework.ReactiveUI.Interfaces;
using ExtensionFramework.ReactiveUI.Services;
using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Configurations;

public readonly struct ReactiveUIDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterScope<IModuleSetup, ReactiveUIModuleSetup>();
        register.RegisterScope<IViewLocator, ModuleViewLocator>();
        register.RegisterScope<INavigator, Navigator>();
        register.RegisterSingleton(new RoutingState());
    }
}