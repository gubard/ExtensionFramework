using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.Core.DependencyInjection.Models;

public readonly record struct AutoInjectMemberIdentifier(
    TypeInformation Type,
    AutoInjectMember Member
);