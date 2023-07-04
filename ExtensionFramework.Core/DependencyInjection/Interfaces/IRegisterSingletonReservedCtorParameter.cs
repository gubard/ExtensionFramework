using System.Linq.Expressions;
using ExtensionFramework.Core.DependencyInjection.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterSingletonReservedCtorParameter
{
    void RegisterSingletonReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    );
}