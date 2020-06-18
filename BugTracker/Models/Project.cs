﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Project
    {
        public Project()
        {
            ProjectUsers = new HashSet<ProjectUser>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<ProjectUser> ProjectUsers { get; set; }

    }
}