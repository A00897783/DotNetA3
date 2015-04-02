namespace a2.Migrations
{
    using a2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<a2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(a2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Worker"))
            {
                var role = new IdentityRole { Name = "Worker" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Reporter"))
            {
                var role = new IdentityRole { Name = "Reporter" };

                manager.Create(role);
            }

            var usrstore = new UserStore<ApplicationUser>(context);
            var usrmanager = new UserManager<ApplicationUser>(usrstore);


            if (!context.Users.Any(u => u.Email == "adam@gs.ca"))
            {
                var user = new ApplicationUser { UserName = "adam@gs.ca", Email = "adam@gs.ca", LockoutEnabled = false };

                usrmanager.Create(user, "P@$$w0rd");
                usrmanager.AddToRole(user.Id, "Administrator");
            }

            if (!context.Users.Any(u => u.Email == "wendy@gs.ca"))
            {
                var user = new ApplicationUser { UserName = "wendy@gs.ca", Email = "wendy@gs.ca", LockoutEnabled =  true };

                usrmanager.Create(user, "P@$$w0rd");
                usrmanager.AddToRole(user.Id, "Worker");
            }

            if (!context.Users.Any(u => u.Email == "rob@gs.ca"))
            {
                var user = new ApplicationUser { UserName = "rob@gs.ca", Email = "rob@gs.ca", LockoutEnabled = true };

                usrmanager.Create(user, "P@$$w0rd");
                usrmanager.AddToRole(user.Id, "Reporter");
            }
        }
    }
}
