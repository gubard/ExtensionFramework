using System.Reflection;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class AssemblyResourceLoader : IResourceLoader
{
    private readonly Assembly assembly;

    public AssemblyResourceLoader(Assembly assembly)
    {
        this.assembly = assembly;
    }
    
    public Stream GetResource(string path)
    {
        var stream = assembly.GetManifestResourceStream($"{assembly.FullName}.{path}");
       
        return stream.ThrowIfNull();
    }
}