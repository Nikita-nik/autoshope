using autttoshope.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@yandex.ru";
            string password = "AdmiN777";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                Person admin = new Person { Email = adminEmail, UserName = adminEmail }; //надо подклюсить айдентити к Person и все будет норм
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
