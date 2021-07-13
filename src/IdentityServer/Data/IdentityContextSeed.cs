using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    public class IdentityContextSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));

                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (!userManager.Users.Any())
            {
                // Create user.
                var user = new IdentityUser
                {
                    UserName = "user"                
                };

                await userManager.CreateAsync(user, "user");

                await userManager.AddToRoleAsync(user, "user");

                await userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Tom"),
                        new Claim(JwtClaimTypes.MiddleName, "Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Tom"),
                        new Claim(JwtClaimTypes.Email, "tomSmith90@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                });

                // Create admin.
                var admin = new IdentityUser
                {
                    UserName = "admin"
                };

                await userManager.CreateAsync(admin, "admin");

                await userManager.AddToRolesAsync(admin, new[] { "admin", "user" });

                await userManager.AddClaimsAsync(admin, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Bob"),
                        new Claim(JwtClaimTypes.MiddleName, "Johnson"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.Email, "bob_johnson@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                });
            }
        }
    } 
}
