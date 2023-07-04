using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Models;

public class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
{
    public RoutableViewModelBase(string? urlPathSegment)
    {
        UrlPathSegment = urlPathSegment;
    }

    public string? UrlPathSegment { get; }
    public IScreen? HostScreen => null;
}