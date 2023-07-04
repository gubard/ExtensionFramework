using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.ModularSystem.Interfaces;

namespace ExtensionFramework.Core.ModularSystem.Extensions;

public static class ModuleTreeExtension
{
    public static T GetObject<T>(this IModule module)
    {
        return module.GetObject(typeof(T)).ThrowIfIsNot<T>();
    }
}