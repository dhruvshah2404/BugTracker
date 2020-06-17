using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public static class RoleAndUserHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        private static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
          (new UserStore<ApplicationUser>(db));
        private static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));

		//Add User
		public static void CreateUser(string email,string password = "123456")
		{
			ApplicationUser user = new ApplicationUser() { Email = email, UserName = email };

			userManager.Create(user, password);
			db.SaveChanges();
		}

		//Create Role
		public static bool CreateRole(string roleName)
		{
			if (roleManager.RoleExists(roleName))
			{
				return false;
			}
			else
			{
				IdentityRole newRole = new IdentityRole(roleName);
				roleManager.Create(newRole);
				db.SaveChanges();
				return true;
			}
		}

		//Delete Role
		public static void DeleteRole(string roleName)
		{
			if (roleManager.RoleExists(roleName))
			{
				roleManager.Delete(new IdentityRole { Name = roleName });
				db.SaveChanges();
			}
		}

		public static bool CheckIfUserIsInRole(string userId, string role)
		{
			var result = userManager.IsInRole(userId, role);
			return result;
		}
		//Add Role To User
		public static bool AddRoleToUser(string userName, string roleName)
		{
			IdentityRole role = roleManager.FindByName(roleName);
			ApplicationUser user = userManager.FindByName(userName);
			if (role != null && user != null && !userManager.IsInRole(user.Id, roleName))
			{
				userManager.AddToRole(user.Id, roleName);
				db.SaveChanges();
				return true;
			}
            else
            {
				return false;
            }
		}
		//Remove Role from User
		public static bool RemoveUserFromRole(string userName, string roleName)
		{
			IdentityRole role = roleManager.FindByName(roleName);
			ApplicationUser user = userManager.FindByName(userName);
			if (!CheckIfUserIsInRole(user.Id, role.Name))
			{
				return false;
			}
			else
			{
				userManager.RemoveFromRole(user.Id, role.Name);
				db.SaveChanges();
				return true;
			}
		}
		//Get All Roles in System
		public static List<string> GetAllRoles()
		{
			return db.Roles.Select(r => r.Name).ToList();
		}

	}
}