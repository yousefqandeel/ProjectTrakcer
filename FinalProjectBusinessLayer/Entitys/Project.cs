using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// Created by Project Manager
    /// </summary>
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime Deadline { get; set; }
        public List<ProjectMembers> ProjectMembers { get; set; }
        public List<Sprint> Sprints { get; set; }
    }
}
