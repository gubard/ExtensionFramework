using System.Reactive.Linq;
using System.Windows.Input;
using ExtensionFramework.Core.DependencyInjection.Attributes;
using ExtensionFramework.Core.Ui.Interfaces;
using ExtensionFramework.ReactiveUI.Interfaces;
using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Models;

public class ViewModelBase : NotifyBase, IIsDialog
{
    private static readonly TimeSpan TaskTimeout = TimeSpan.FromMilliseconds(120);

    public ViewModelBase()
    {
        NavigateBackCommand = ReactiveCommand.CreateFromObservable(
            () => Navigator is null ? Observable.Empty<IRoutableViewModel>() : Navigator.NavigateBack()
        );

        CloseDialogCommand = ReactiveCommand.Create(() => DialogViewer?.CloseDialog());

        BackCommand = ReactiveCommand.Create(
            () =>
            {
                if (IsDialog)
                {
                    CloseDialogCommand.Execute(null);
                }
                else
                {
                    NavigateBackCommand.Execute(null);
                }
            }
        );
    }

    [Inject]
    public required INavigator Navigator { get; init; }

    [Inject]
    public required IDialogViewer DialogViewer { get; set; }

    public ICommand NavigateBackCommand { get; }
    public ICommand CloseDialogCommand { get; }
    public ICommand BackCommand { get; }
    public bool IsDialog { get; set; }

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

    protected ICommand CreateCommandFromTaskWithDialogProgressIndicator(Func<Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(CreateWithDialogProgressIndicatorAsync(execute));
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommandFromTaskWithDialogProgressIndicator<TParam>(Func<TParam, Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(CreateWithDialogProgressIndicatorAsync(execute));
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

    protected Func<Task> CreateWithDialogProgressIndicatorAsync(Func<Task> execute)
    {
        return async () =>
        {
            var task = execute.Invoke();

            if (await IsTakeMoreThen(task, TaskTimeout))
            {
                DialogViewer.ShowDialogAsync(typeof(IDialogProgressIndicator));
                await task;
                DialogViewer.CloseDialog();
            }

            await task;
        };
    }

    protected Func<TParam, Task> CreateWithDialogProgressIndicatorAsync<TParam>(Func<TParam, Task> execute)
    {
        return async param =>
        {
            var task = execute.Invoke(param);

            if (await IsTakeMoreThen(task, TaskTimeout))
            {
                DialogViewer.ShowDialogAsync(typeof(IDialogProgressIndicator));
                await task;
                DialogViewer.CloseDialog();
            }

            await task;
        };
    }

    private async Task<bool> IsTakeMoreThen(Task task, TimeSpan timeout)
    {
        var tasks = new[]
        {
            task, Task.Delay(timeout),
        };

        var resultTask = await Task.WhenAny(tasks);

        return resultTask != task;
    }

    private void SetupCommand<TParam, TResult>(ReactiveCommand<TParam, TResult> command)
    {
        command.ThrownExceptions.Subscribe(
            exception =>
            {
                Navigator.NavigateTo<IExceptionViewModel>(viewModel => viewModel.Exception = exception);
                DialogViewer.CloseDialog();
            }
        );
    }
}