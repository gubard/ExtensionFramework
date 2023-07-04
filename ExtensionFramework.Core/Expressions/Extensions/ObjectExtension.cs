using System.Linq.Expressions;

namespace ExtensionFramework.Core.Expressions.Extensions;

public static class ObjectExtension
{
    public static ConstantExpression ToConstant(this object obj)
    {
        return Expression.Constant(obj);
    }

    public static ConstantExpression ToConstant(this object obj, Type type)
    {
        return Expression.Constant(obj, type);
    }
}