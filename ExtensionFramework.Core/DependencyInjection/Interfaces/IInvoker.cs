using System.Reflection;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IInvoker
{
    object? Invoke(Delegate del, DictionarySpan<TypeInformation, object> arguments);
    object? Invoke(object? obj, MethodInfo method, DictionarySpan<TypeInformation, object> arguments);
}