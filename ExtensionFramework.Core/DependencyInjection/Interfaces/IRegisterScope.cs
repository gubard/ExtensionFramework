using System.Linq.Expressions;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterScope
{
    void RegisterScope(Type type, Expression expression);
}