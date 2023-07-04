using System.Linq.Expressions;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterSingleton
{
    void RegisterSingleton(Type type, Expression expression);
}