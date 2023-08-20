namespace ExtensionFramework.Core.Ui.Models;

public class AppConfiguration
{
    public AppConfiguration(Type defaultMainViewType)
    {
        DefaultMainViewType = defaultMainViewType;
    }

    public Type DefaultMainViewType { get; }
}