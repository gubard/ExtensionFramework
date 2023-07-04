namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IDependencyInjectorConfiguration
{
    void Configure(IDependencyInjectorRegister register);
}