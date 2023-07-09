using Avalonia;
using ExtensionFramework.AvaloniaUi.Controls;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.DependencyInjection.Extensions;
using ExtensionFramework.Core.DependencyInjection.Models;
using ExtensionFramework.Core.Expressions.Extensions;

namespace ExtensionFramework.AvaloniaUi.Configurations;

public readonly struct AvaloniaUiDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterTransient<PathControl>();
        RegisterViewModels(register);
    }

    private void RegisterViewModels(IDependencyInjectorRegister register)
    {
        var styledElementType = typeof(StyledElement);
        var member = styledElementType.GetProperty(nameof(StyledElement.DataContext)).ThrowIfNull();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var autoInjectMember = new AutoInjectMember(member);

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Namespace.IsNullOrWhiteSpace())
                {
                    continue;
                }

                if (!styledElementType.IsAssignableFrom(type))
                {
                    continue;
                }

                var ns = type.Namespace
                    .Replace(".Views.", ".ViewModels.")
                    .Replace(".Views", ".ViewModels");

                var viewModelName = $"{ns}.{type.Name}Model";
                var viewModelType = assembly.GetType(viewModelName);

                if (viewModelType is null)
                {
                    continue;
                }

                var autoInjectIdentifier = new AutoInjectMemberIdentifier(type, autoInjectMember);
                var variable = viewModelType.ToVariableAutoName();
                register.RegisterScope(type);
                register.RegisterScope(viewModelType);

                register.RegisterScopeAutoInjectMember(
                    autoInjectIdentifier,
                    variable.ToLambda(variable)
                );
            }
        }
    }
}