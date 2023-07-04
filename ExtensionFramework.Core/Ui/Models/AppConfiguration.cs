namespace ExtensionFramework.Core.Ui.Models;

public class AppConfiguration
{
    public AppConfiguration(Type defaultMainViewType, IReadOnlyDictionary<Type, Type> viewPipe)
    {
        DefaultMainViewType = defaultMainViewType;
        ViewPipe = viewPipe;
    }

    public Type DefaultMainViewType { get; }

    public IReadOnlyDictionary<Type, Type> ViewPipe { get; }
}