using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Interfaces;

public interface INavigator
{
    IObservable<IRoutableViewModel?> NavigateBack();
    IObservable<IRoutableViewModel> NavigateTo<TViewModel>(TViewModel parameter) where TViewModel : IRoutableViewModel;
    IObservable<IRoutableViewModel> NavigateTo(Type type);

    IObservable<IRoutableViewModel> NavigateTo<TViewModel>(Action<TViewModel>? setup = null)
        where TViewModel : IRoutableViewModel;
}