using FinalProjectBusinessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class TeamMemberDTO
    {
        public string MemberID { get; set; }
        public string FullName { get; set; }
        public List<Duty> Duties { get; set; }
    }
}
