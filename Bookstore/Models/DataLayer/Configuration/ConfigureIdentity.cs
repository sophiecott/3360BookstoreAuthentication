using Microsoft.AspNetCore.Identity;

namespace Bookstore.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider) // new async task to create the adminuserasync method
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>(); // create new variable with the rolemanager provide
            var userManager = provider.GetRequiredService<UserManager<User>>(); // create new variable for the UserManager provider

            string username = "admin"; // for the admin make the username "admin"
            string password = "Sesame"; // for the admin login password make is "Sesame"
            string roleName = "Admin"; // the role name is Admin

            if (await roleManager.FindByNameAsync(roleName) == null) // if the rolemanager is equal to null
            {
                await roleManager.CreateAsync(new IdentityRole(roleName)); // await new identity role
            }

            if (await userManager.FindByNameAsync(username) == null) // if the usermanager has a username it's equal to null
            {
                User user = new User { UserName = username }; // create new user
                var result = await userManager.CreateAsync(user, password); // with the username and password

                if (result.Succeeded) // if the result succeeded
                {
                    await userManager.AddToRoleAsync(user, roleName); // add the role name user to the Roles
                }
            }
        }
    }

}
