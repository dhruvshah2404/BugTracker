using BugTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTracker.Controllers
{
    public class ProjectsController : Controller
    {
         ApplicationDbContext db = new ApplicationDbContext();// the database

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }
        public ActionResult MyProjects(string id)
        {
            var projects = db.ProjectUsers.Where(p => p.UserId == id).Select(u => u.Project).ToList();
            if (true)
            {

            }
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

        [Authorize(Roles = "Project Manager,Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = db.Projects.Include(t => t.Tickets).Include(u => u.Users)
                .Where(x => x.Id == id)
               .FirstOrDefault();

            return View(project);
        }
        //Adding Developer to Project
        [Authorize(Roles = "Project Manager,Admin")]
        public ActionResult AddUser(int projectId)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var users = roleManager.FindByName("Developer").Users.Select(u => u.UserId).ToList();
            var developers = db.Users.Where(e => users.Contains(e.Id)).ToList();

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.UserId = new SelectList(developers, "Id", "UserName");
            ViewBag.Project = projectId;
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(int ProjectId, string UserId)
        {
            var ProjectUser = new ProjectUser() { ProjectId = ProjectId, UserId = UserId };
            if (ModelState.IsValid)
            {
                if (!db.ProjectUsers.Any(p => p.ProjectId == ProjectId && p.UserId == UserId))
                {
                    db.ProjectUsers.Add(ProjectUser);
                    db.SaveChanges();
                    return RedirectToAction("Info", new { id = ProjectId });
                }
                else
                {
                    ViewBag.message = "User Already there";
                    return RedirectToAction("Info", new { id = ProjectId });
                }
            }
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var users = roleManager.FindByName("Developer").Users.Select(u => u.UserId).ToList();
            var developers = db.Users.Where(e => users.Contains(e.Id)).ToList();

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.UserId = new SelectList(developers, "Id", "UserName");
            return View(ProjectUser);
        }

        [Authorize(Roles = "Project Manager,Admin")]
        //remove developer
        public ActionResult RemoveFromProject(int projectId, string userId)
        {
            var project = db.ProjectUsers.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == userId);
            db.ProjectUsers.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Info", new { id = projectId });
        }
    }
}