namespace ExtensionFramework.Core.Ui.Interfaces;

public interface IDialogViewer
{
    Task<object?> ShowDialogAsync(Type contentType);
    Task<object?> ShowDialogAsync<TView>(Action<TView>? setup = null) where TView : notnull;
    void CloseDialog();
}