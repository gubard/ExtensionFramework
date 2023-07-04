using System.Windows.Input;
using ExtensionFramework.Core.DependencyInjection.Attributes;
using ExtensionFramework.ReactiveUI.Interfaces;
using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Models;

public class ViewModelBase : NotifyBase
{
    [Inject]
    public required INavigator Navigator { get; init; }

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

    private void SetupCommand<TParam, TResult>(ReactiveCommand<TParam, TResult> command)
    {
        command.ThrownExceptions.Subscribe(
            exception => Navigator.NavigateTo<IExceptionViewModel>(viewModel => viewModel.Exception = exception)
        );
    }
}