using FinalProjectBusinessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class DutyDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TeamMemberID { get; set; }
        public int SprintID { get; set; }
        public int StatusID { get; set; }
    }
}
