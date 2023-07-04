using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IResolver
{
    object Resolve(TypeInformation type);
}