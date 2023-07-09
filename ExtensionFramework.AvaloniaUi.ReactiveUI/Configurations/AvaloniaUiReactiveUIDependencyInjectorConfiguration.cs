using Avalonia.ReactiveUI;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.DependencyInjection.Extensions;
using ReactiveUI;

namespace ExtensionFramework.AvaloniaUi.ReactiveUI.Configurations;

public readonly struct AvaloniaUiReactiveUIDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterScopeAutoInjectMember((RoutedViewHost host) => host.Router, (RoutingState state) => state);
    }
}