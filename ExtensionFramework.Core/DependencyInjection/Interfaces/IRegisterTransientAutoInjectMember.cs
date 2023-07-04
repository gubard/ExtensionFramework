using System.Linq.Expressions;
using ExtensionFramework.Core.DependencyInjection.Models;

namespace ExtensionFramework.Core.DependencyInjection.Interfaces;

public interface IRegisterTransientAutoInjectMember
{
    void RegisterTransientAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    );
}