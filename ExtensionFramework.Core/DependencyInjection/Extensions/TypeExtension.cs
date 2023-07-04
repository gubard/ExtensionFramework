using System.Reflection;
using ExtensionFramework.Core.DependencyInjection.Exceptions;

namespace ExtensionFramework.Core.DependencyInjection.Extensions;

public static class TypeExtension
{
    public static ConstructorInfo? GetSingleConstructor(this Type type)
    {
        var constructors = type.GetConstructors();

        if (constructors.Length == 0)
        {
            return null;
        }

        if (constructors.Length > 1)
        {
            throw new ToManyConstructorsException(type, 1, constructors.Length);
        }

        return constructors[0];
    }
}