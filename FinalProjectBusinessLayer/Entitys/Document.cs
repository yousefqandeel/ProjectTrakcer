using System;
using System.Collections.Generic;
using System.Text;
namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// The task that was performed by the team member
    /// </summary>
    public class Document
    {
        public int DocumentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Duty Duty { get; set; }
        public int DutyID { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        public List<DocumentAttatchment> DocumentAttatchments { get; set; }
    }
}