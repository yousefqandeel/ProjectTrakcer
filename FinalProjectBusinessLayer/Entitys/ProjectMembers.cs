using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// Who is chosen by the team leader to carry out the tasks required of him
    /// </summary>
    public class ProjectMembers
    {
        public Member Member { get; set; }
        public string MemberID { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }

    }
}
