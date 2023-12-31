using System.Linq.Expressions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.Expressions.Extensions;

namespace ExtensionFramework.Core.DependencyInjection.Extensions;

public static class RegisterSingletonExtension
{
    public static void RegisterSingleton<T>(
        this IRegisterSingleton registerSingleton,
        Expression expression
    )
    {
        registerSingleton.RegisterSingleton(typeof(T), expression);
    }

    public static void RegisterSingleton<T>(this IRegisterSingleton registerSingleton)
    {
        registerSingleton.RegisterSingleton<T>((T value) => value);
    }

    public static void RegisterSingleton<T>(this IRegisterSingleton registerSingleton, T value)
    {
        registerSingleton.RegisterSingleton(typeof(T), value.ToConstant());
    }

    public static void RegisterSingleton<T, TImp>(this IRegisterSingleton registerSingleton)
        where TImp : notnull, T
    {
        registerSingleton.RegisterSingleton<T>((TImp imp) => imp);
    }
}