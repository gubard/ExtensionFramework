using Avalonia.ReactiveUI;
using ExtensionFramework.Core.Common.Extensions;

namespace ExtensionFramework.AvaloniaUi.ReactiveUI.Models;

public class MainReactiveUserControl<T> : ReactiveUserControl<T> where T : class
{
    public T MainViewModel => ViewModel.ThrowIfNull();
}