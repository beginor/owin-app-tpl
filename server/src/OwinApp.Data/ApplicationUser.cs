using System.Linq;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Data {
    
    public class ApplicationUser : IdentityUser { }

    public static class IdentityUserExtensions {

        public static string GetClaimValue(
            this IdentityUser user,
            string claimType
        ) {
            var claim = user.Claims.FirstOrDefault(c => c.ClaimType == claimType);
            return claim?.ClaimValue;
        }

        public static void SetClaimValue(
            this IdentityUser user,
            string claimType,
            string claimValue
        ) {
            var claim = user.Claims.FirstOrDefault(c => c.ClaimType == claimType);
            if (claim == null) {
                AddClaim(user, claimType, claimValue);
            }
            else {
                claim.ClaimValue = claimValue;
            }
        }

        public static void AddClaim(
            this IdentityUser user,
            string claimType,
            string claimValue
        ) {
            user.AddClaim(claimType, claimValue);
        }

        public static void RemoveClaimsByType(
            this IdentityUser user,
            string claimType
        ) {
            var claims = user.Claims
                .Where(claim => claim.ClaimType == claimType)
                .ToList();
            foreach (var c in claims) {
                user.Claims.Remove(c);
            }
        }
    }

}
