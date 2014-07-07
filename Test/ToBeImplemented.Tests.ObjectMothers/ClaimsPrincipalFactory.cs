namespace ToBeImplemented.Tests.ObjectMothers
{
    using System.Linq;
    using System.Security.Claims;

    using ToBeImplemented.Common.Data;

    public static class ClaimsPrincipalFactory
    {
        public static ClaimsPrincipal CreateWithUserId(long authorId)
        {
            var claim = new Claim(ToBeImplementedClaims.IdClaim, authorId.ToString());
            var identity = new ClaimsIdentity(Enumerable.Repeat(claim, 1));
            var claimsprincipal = new ClaimsPrincipal(identity);
            return claimsprincipal;
        }
    }
}