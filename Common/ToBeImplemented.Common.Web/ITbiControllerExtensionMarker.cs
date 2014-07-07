namespace ToBeImplemented.Common.Web
{
    using System.Web;

    public interface ITbiControllerExtensionMarker
    {
        HttpContext CurrentContext { get; }
    }
}