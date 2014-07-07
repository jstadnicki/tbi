namespace ToBeImplemented.Common.Web
{
    using System.Security.Claims;
    using System.Web;

    using Microsoft.Owin.Security;

    public static class TbiControllerExtension
    {
        public static IAuthenticationManager OwinAuthenticationManager(this ITbiControllerExtensionMarker controller)
        {
            return controller.CurrentContext.GetOwinContext().Authentication;
        }

        public static ClaimsPrincipal CurrentUser(this ITbiControllerExtensionMarker controller)
        {
            return controller.CurrentContext.GetOwinContext().Authentication.User;
        }
    }
}