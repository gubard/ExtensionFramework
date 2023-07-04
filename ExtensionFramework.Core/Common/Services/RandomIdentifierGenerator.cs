using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class RandomIdentifierGenerator<TKey> : IIdentifierGenerator<TKey>
{
    private readonly IRandom<TKey> random;

    public RandomIdentifierGenerator(IRandom<TKey> random)
    {
        this.random = random;
    }

    public TKey Generate()
    {
        return random.GetRandom().ThrowIfNull();
    }
}