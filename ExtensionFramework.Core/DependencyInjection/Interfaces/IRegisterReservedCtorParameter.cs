namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterReservedCtorParameter
    : IRegisterSingletonReservedCtorParameter,
        IRegisterTransientReservedCtorParameter
{
}