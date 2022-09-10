using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class TeamLeaderForProjectDTO
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public int ProjectID { get; set; }
        public string RoleID { get; set; }
    }
}
