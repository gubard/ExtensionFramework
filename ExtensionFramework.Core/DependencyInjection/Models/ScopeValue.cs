using System.Linq.Expressions;

namespace ExtensionFramework.Core.DependencyInjection.Models;

public readonly record struct ScopeValue(ParameterExpression Parameter, Expression Expression);