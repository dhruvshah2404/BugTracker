using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{ 
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var roleList = db.Roles.Select(roles => new SelectListItem { Value = roles.Name.ToString(), Text = roles.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = db.Users.Select(users => new SelectListItem { Value = users.UserName.ToString(), Text = users.UserName }).ToList();
            ViewBag.Users = userList;

            return View();
        }
    
        //GET:CREATE ROLE
        public ActionResult CreatingRole()
        {
            return View();
        }

        //POST: CREATE ROLE
        [HttpPost]
        public ActionResult CreatingRole(string role)
        {
            if (RoleAndUserHelper.CreateRole(role))
            {
                ViewBag.message = "Role Created";
            }
            else
            {
                ViewBag.message = "Role Already Exist";
            }
            return RedirectToAction("Index");
        }

        //GET
        public ActionResult AddRoleToUser()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult AddRoleToUser(string email, string role)
        {
            ApplicationUser user = db.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (RoleAndUserHelper.AddRoleToUser(user.Email, role))
            {
                ViewBag.message = "Role Added to User";
            }
            else
            {
                ViewBag.message = "User is already in this Role";
            }

            var roleList = db.Roles.Select(roles => new SelectListItem { Value = roles.Name.ToString(), Text = roles.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = db.Users.Select(users => new SelectListItem { Value = users.UserName.ToString(), Text = users.UserName }).ToList();
            ViewBag.Users = userList;
            return View("Index");
        }

        //Get
        public ActionResult RemoveRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveRole(string email,string role)
        {
            ApplicationUser user = db.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (RoleAndUserHelper.RemoveUserFromRole(user.Email, role))
            {
                ViewBag.message = "User removed from role";
            }
            else
            {
                ViewBag.message = "User is not in this role";
            }

            var roleList = db.Roles.Select(roles => new SelectListItem { Value = roles.Name.ToString(), Text = roles.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = db.Users.Select(users => new SelectListItem { Value = users.UserName.ToString(), Text = users.UserName }).ToList();
            ViewBag.Users = userList;
            return View("Index");
        }
    }
}