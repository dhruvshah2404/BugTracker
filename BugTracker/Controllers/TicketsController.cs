using BugTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class TicketsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();// the database

        // GET: Tickets
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var tickets = db.Tickets.Where(t => t.OwnerUserId == userId);
            return View(tickets);
        }
        public ActionResult Create()
        {
            ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name");
            ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name");
            return View();

        }
        [HttpPost]
        public ActionResult Create(string Title, string Description, int TicketTypeId, int TicketPriorityId)
        {
            TicketHelper.Create(Title, Description, TicketTypeId, TicketPriorityId);
            return RedirectToAction("Index");
        }
    }
}