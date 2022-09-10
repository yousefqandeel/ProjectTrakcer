using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class TeamMemberForProject
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public int SprintID { get; set; }
        public string RoleID { get; set; }
    }
}
