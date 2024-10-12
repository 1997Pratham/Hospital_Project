using Hospital_Model;
using Hospital_Repository;
using Hospital_Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Utility
{
    public class DbInitiazer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _Context;

        public DbInitiazer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _Context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_Context.Database.GetPendingMigrations().Count() > 0)
                {
                    _Context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRole.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.WebSite_Doctor)).GetAwaiter().GetResult();

                //_roleManager.CreateAsync(new ApplicationUser
                //{
                //    UserName = "Vipin",
                //    Email = "Vipin@gmail.com"
                //}, "Vipin@12345").GetAwaiter().GetResult();
                //var AppUser = _Context.ApplicationUsers.FirstOrDefault(x => x.Email == "Vipin@gmail.com");
                //if (AppUser != null)
                //{
                //    _userManager.AddToRoleAsync(AppUser, WebSiteRole.WebSite_Admin).GetAwaiter().GetResult();
                //}

                var user = new ApplicationUser
                {
                    UserName = "Vipin",
                    Email = "Vipin@gmail.com"
                };

                _userManager.CreateAsync(user);
                 _userManager.AddPasswordAsync(user, "Vipin@12345");

                var appUser = _Context.ApplicationUsers.FirstOrDefault(x => x.Email == "Vipin@gmail.com");
                if (appUser != null)
                {
                   _userManager.AddToRoleAsync(appUser, WebSiteRole.WebSite_Admin.ToString());
                }
            }
        }

    }
}



