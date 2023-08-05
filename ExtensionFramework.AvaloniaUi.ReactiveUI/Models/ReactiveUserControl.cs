using ExtensionFramework.Core.Common.Extensions;

namespace ExtensionFramework.AvaloniaUi.ReactiveUI.Models;

public class ReactiveUserControl<T> : Avalonia.ReactiveUI.ReactiveUserControl<T> where T : class
{
    public T MainViewModel => ViewModel.ThrowIfNull();
}