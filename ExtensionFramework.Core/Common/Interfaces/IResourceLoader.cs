namespace ExtensionFramework.Core.Common.Interfaces;

public interface IResourceLoader
{
    Stream GetResource(string path);
}