using System.Text;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class StreamEncodingHumanizing : IHumanizing<Stream, string>
{
    private readonly Encoding encoding;

    public StreamEncodingHumanizing(Encoding encoding)
    {
        this.encoding = encoding.ThrowIfNull();
    }

    public StreamEncodingHumanizing() : this(Encoding.UTF8)
    {
    }

    public string Humanize(Stream input)
    {
        var bytes = input.ReadAll();
        var result = encoding.GetString(bytes);

        return result;
    }
}