using ReactiveUI;

namespace ExtensionFramework.ReactiveUI.Interfaces;

public interface IExceptionViewModel : IRoutableViewModel
{
    Exception Exception { get; set; }
}