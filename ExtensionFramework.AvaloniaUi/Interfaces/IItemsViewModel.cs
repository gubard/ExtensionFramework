using Avalonia.Collections;

namespace ExtensionFramework.AvaloniaUi.Interfaces;

public interface IItemsViewModel<TItem>
{
    AvaloniaList<TItem> Items { get; }
}