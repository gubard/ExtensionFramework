namespace ExtensionFramework.Core.Common.Interfaces;

public interface IIdentifierGenerator<out TKey>
{
    TKey Generate();
}