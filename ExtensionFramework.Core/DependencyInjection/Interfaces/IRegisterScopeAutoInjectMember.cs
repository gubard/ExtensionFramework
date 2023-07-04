using System.Linq.Expressions;
using ExtensionFramework.Core.DependencyInjection.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterScopeAutoInjectMember
{
    void RegisterScopeAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    );
}