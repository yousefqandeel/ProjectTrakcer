using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// Status of Duties and Documents
    /// </summary>
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public List<Duty> Duties { get; set; }
        public List<Document> Documents { get; set; }
    }
}
