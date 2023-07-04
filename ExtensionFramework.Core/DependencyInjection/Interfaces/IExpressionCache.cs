using System.Linq.Expressions;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IExpressionCache
{
    void CacheExpression(TypeInformation type);
    Expression? GetCacheExpression(TypeInformation type);
}