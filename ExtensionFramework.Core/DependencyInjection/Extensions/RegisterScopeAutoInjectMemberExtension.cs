using System.Diagnostics;
using System.Linq.Expressions;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.DependencyInjection.Models;

namespace ExtensionFramework.Core.DependencyInjection.Extensions;

public static class RegisterScopeAutoInjectMemberExtension
{
    public static void RegisterScopeAutoInjectMember(
        this IRegisterScopeAutoInjectMember register,
        Expression path,
        Expression value
    )
    {
        switch (path)
        {
            case LambdaExpression lambdaExpression:
            {
                var type = lambdaExpression.Parameters.Single().Type;
                var memberExpression = lambdaExpression.Body.ThrowIfIsNot<MemberExpression>();
                var identifier = new AutoInjectMemberIdentifier(type, memberExpression.Member);
                register.RegisterScopeAutoInjectMember(identifier, value);

                break;
            }
            default:
            {
                throw new UnreachableException();
            }
        }
    }
}