using DialogHostAvalonia;
using ExtensionFramework.Core.DependencyInjection.Attributes;
using ExtensionFramework.Core.DependencyInjection.Extensions;
using ExtensionFramework.Core.DependencyInjection.Interfaces;
using ExtensionFramework.Core.Ui.Interfaces;

namespace ExtensionFramework.AvaloniaUi.Services;

public class DialogViewer : IDialogViewer
{
    public const string DefaultDialogIdentifier = "MainDialogHost";

    private readonly string dialogIdentifier;

    private static object? currentContent;

    public DialogViewer(string dialogIdentifier)
    {
        this.dialogIdentifier = dialogIdentifier;
    }

    [Inject]
    public required IResolver Resolver { get; init; }

    public Task<object?> ShowDialogAsync(Type contentType)
    {
        var content = Resolver.Resolve(contentType);

        return DialogHost.Show(content, dialogIdentifier);
    }

    public Task<object?> ShowDialogAsync<TView>(Action<TView>? setup) where TView : notnull
    {
        var content = Resolver.Resolve<TView>();
        setup?.Invoke(content);
        currentContent = content;

        return DialogHost.Show(content, dialogIdentifier);
    }

    public void CloseDialog()
    {
        if (DialogHost.IsDialogOpen(dialogIdentifier))
        {
            DialogHost.Close(dialogIdentifier, currentContent);
        }
    }
}