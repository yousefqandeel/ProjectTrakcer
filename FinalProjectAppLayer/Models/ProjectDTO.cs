using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string TeamLeaderID { get; set; }
        public string TeamLeaderName { get; set; }
    }
}
