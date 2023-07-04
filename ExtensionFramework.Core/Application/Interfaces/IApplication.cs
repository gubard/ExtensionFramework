namespace ExtensionFramework.Core.Application.Interfaces;

public interface IApplication
{
    void Run(string[] args);

    Task RunAsync(string[] args);
}