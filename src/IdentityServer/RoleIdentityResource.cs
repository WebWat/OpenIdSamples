using IdentityModel;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class RoleIdentityResource : IdentityResources.Profile
    {
        public RoleIdentityResource() => UserClaims.Add(JwtClaimTypes.Role);
    }
}
