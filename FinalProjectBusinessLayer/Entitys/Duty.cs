using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// The task to be performed by the team member
    /// </summary>
    public class Duty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //I got an error related to DytyID column, because of that after search in google I found this line and problem was fixed
        public int DutyID { get; set; }
        public string DutyName { get; set; }
        public string DutyDesctiption { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Sprint Sprint { get; set; }
        public int SprintID { get; set; }
        public TeamMember TeamMember { get; set; }
        public string TeamMemberID { get; set; }
        public Status Statuses { get; set; }
        public int StatusID { get; set; }
        public List<Document> Documents { get; set; }
    }
}
