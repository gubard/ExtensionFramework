using ExtensionFramework.Core.DependencyInjection.Attributes;
using ExtensionFramework.Core.DependencyInjection.Extensions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.Ui.Models;
using ExtensionFramework.ReactiveUI.Interfaces;
using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Services;

public class Navigator : INavigator
{
    [Inject]
    public required RoutingState RoutingState { get; init; }

    [Inject]
    public required IResolver Resolver { get; init; }

    [Inject]
    public required AppConfiguration Configuration { get; init; }

    public IObservable<IRoutableViewModel?> NavigateBack()
    {
        return NavigateTo(Configuration.DefaultMainViewType);
    }

    public IObservable<IRoutableViewModel> NavigateTo(Type type)
    {
        var viewModel = (IRoutableViewModel)Resolver.Resolve(type);

        return RoutingState.Navigate.Execute(viewModel);
    }

    public IObservable<IRoutableViewModel> NavigateTo<TViewModel>(Action<TViewModel>? setup = null)
        where TViewModel : IRoutableViewModel
    {
        var viewModel = Resolver.Resolve<TViewModel>();

        if (setup is null)
        {
            return RoutingState.Navigate.Execute(viewModel);
        }

        setup.Invoke(viewModel);

        return RoutingState.Navigate.Execute(viewModel);
    }

    public IObservable<IRoutableViewModel> NavigateTo<TViewModel>(TViewModel parameter)
        where TViewModel : IRoutableViewModel
    {
        return RoutingState.Navigate.Execute(parameter);
    }
}