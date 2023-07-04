using System.Reflection;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Models;

public readonly record struct ReservedCtorParameterIdentifier(
    TypeInformation Type,
    ConstructorInfo Constructor,
    ParameterInfo Parameter
);