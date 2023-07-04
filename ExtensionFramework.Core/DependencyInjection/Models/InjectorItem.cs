using System.Linq.Expressions;

namespace ExtensionFramework.Core.DependencyInjection.Models;

public readonly record struct InjectorItem(InjectorItemType Type, Expression Expression);