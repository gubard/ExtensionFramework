using System.Reactive.Linq;
using System.Windows.Input;
using ExtensionFramework.Core.DependencyInjection.Attributes;
using ExtensionFramework.ReactiveUI.Interfaces;
using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Models;

public class ViewModelBase : NotifyBase
{
    public ViewModelBase()
    {
        NavigateBackCommand = ReactiveCommand.CreateFromObservable(
            () =>
            {
                if (Navigator is null)
                {
                    return Observable.Empty<IRoutableViewModel>();
                }

                return Navigator.NavigateBack();
            }
        );
    }

    [Inject]
    public required INavigator Navigator { get; init; }

    public ICommand NavigateBackCommand { get; }

    protected ICommand CreateCommandFromObservable<TResult>(Func<IObservable<TResult>> execute)
    {
        var command = ReactiveCommand.CreateFromObservable(execute);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommand(Action action)
    {
        var command = ReactiveCommand.Create(action);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommand<TArgs>(Action<TArgs> action)
    {
        var command = ReactiveCommand.Create(action);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommandFromTask(Func<Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(execute);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommandFromTask<TParam>(Func<TParam, Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(execute);
        SetupCommand(command);

        return command;
    }

    protected async Task SafeExecuteAsync(Func<Task> func)
    {
        try
        {
            await func.Invoke();
        }
        catch (Exception e)
        {
            Navigator.NavigateTo<IExceptionViewModel>(viewModel => viewModel.Exception = e);
        }
    }

    private void SetupCommand<TParam, TResult>(ReactiveCommand<TParam, TResult> command)
    {
        command.ThrownExceptions.Subscribe(
            exception => Navigator.NavigateTo<IExceptionViewModel>(viewModel => viewModel.Exception = exception)
        );
    }
}