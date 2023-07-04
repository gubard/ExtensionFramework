using System.Linq.Expressions;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterTransient
{
    void RegisterTransient(Type type, Expression expression);
}