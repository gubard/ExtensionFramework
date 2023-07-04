using ExtensionFramework.Core.Graph.Services;

namespace ExtensionFramework.Core.Graph.Extensions;

public static class TreeBuilderExtension
{
    public static TreeBuilder<TKey, TValue> SetRoot<TKey, TValue>(
        this TreeBuilder<TKey, TValue> builder,
        TreeNodeBuilder<TKey, TValue> root
    ) where TKey : notnull
    {
        builder.Root = root!;

        return builder;
    }
}