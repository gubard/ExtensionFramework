using System.Net;
using System.Text;
using ExtensionFramework.Core.Common.Extensions;

namespace ExtensionFramework.Core.Common.Services;

public class UdpSendString : UdpSend<string>
{
    public UdpSendString(IPEndPoint ipEndPoint, Encoding encoding)
        : base(ipEndPoint, s => encoding.GetBytes(s))
    {
        encoding.ThrowIfNull(nameof(encoding));
    }
}