using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RBPServer.Startup))]

namespace RBPServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            InitializeIdentityForEF();
        }

        public void InitializeIdentityForEF()
        {
            var context = new ApplicationDbContext();

            var roleStore = new ApplicationRoleStore(context);
            var roleManager = new ApplicationRoleManager(roleStore);

            var userStore = new ApplicationUserStore(context);
            var userManager = new ApplicationUserManager(userStore);

            const string adminUsername = "admin@gmail.com";
            const string password = "Password123!";
            const string adminRoleName = "Admin";
            const string userRoleName = "User";

            var adminRole = roleManager.FindByName(adminRoleName);
            if (adminRole == null)
            {
                adminRole = new ApplicationRole(adminRoleName);
                var roleResult = roleManager.Create(adminRole);
            }

            var userRole = roleManager.FindByName(userRoleName);
            if (userRole == null)
            {
                userRole = new ApplicationRole(userRoleName);
                var roleResult = roleManager.Create(userRole);
            }

            var adminUser = userManager.FindByName(adminUsername);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminUsername, Email = adminUsername };
                var result = userManager.Create(adminUser, password);
                result = userManager.SetLockoutEnabled(adminUser.Id, false);
            }

            var rolesForUser = userManager.GetRoles(adminUser.Id);
            if (!rolesForUser.Contains(adminRole.Name))
            {
                var result = userManager.AddToRole(adminUser.Id, adminRole.Name);
            }
        }
    }
}
