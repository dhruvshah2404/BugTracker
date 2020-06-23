using BugTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTracker.Controllers
{
    [Authorize(Roles = "Project Manager,Admin")]
    public class ProjectsController : Controller
    {
         ApplicationDbContext db = new ApplicationDbContext();// the database

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }
        //GET
        public ActionResult Create()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var users = roleManager.FindByName("Project Manager").Users.Select(u => u.UserId).ToList();
            var ProjectManagers = db.Users.Where(e => users.Contains(e.Id)).ToList();

            ViewBag.UserId = new SelectList(ProjectManagers, "Id", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name,string UserId)//userId is ProjectManager's Id
        {
            if (ProjectHelper.AddProject(name, UserId))
            {
                ViewBag.message = "Project created and Assigned successfully";

            }
            else
            {
                ViewBag.message = "Project creation unsuccessful";

            }
            return RedirectToAction("Index");
        }

    }
}