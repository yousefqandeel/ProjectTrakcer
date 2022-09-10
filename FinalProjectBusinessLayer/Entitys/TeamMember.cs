using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// Who choosed by Team Leader to carry out the tasks required of them
    /// </summary>
    public class TeamMember : Member
    {
        public List<Duty> Duties { get; set; }
    }
}
