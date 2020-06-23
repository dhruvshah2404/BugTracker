using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public static class ProjectHelper
    {
	
			static ApplicationDbContext db = new ApplicationDbContext();// the database

			// Add() for adding projects to the database
			public static bool AddProject(string name,string userId)
			{
				Project project = new Project() { Name = name};
				db.Projects.Add(project);
				db.SaveChanges();
			ProjectUser projectUser = new ProjectUser() { ProjectId = project.Id, UserId = userId };
			db.ProjectUsers.Add(projectUser);
			db.SaveChanges();
			return true;
			}

			// Delete() for deleting projects from the database
			public static bool Delete(int id)
			{
				var project = db.Projects.Find(id);

				db.Projects.Remove(project);
				db.SaveChanges();
				return true;

			}

		}
	}
