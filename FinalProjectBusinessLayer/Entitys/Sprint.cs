using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// It's created by team leader to divide tasks and must have start and end date
    /// </summary>
    public class Sprint
    {
        public int SprintID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public List<Duty> Duties { get; set; }
    }
}
