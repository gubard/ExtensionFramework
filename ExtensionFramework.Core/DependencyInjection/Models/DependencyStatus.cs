using System.Linq.Expressions;
using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Models;

public readonly struct DependencyStatus
{
    public DependencyStatus(TypeInformation type, Expression expression)
    {
        Expression = expression;
        Type = type;
    }

    public TypeInformation Type { get; }
    public Expression Expression { get; }
}