using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// The file to be handed over by the team member
    /// </summary>
    public class DocumentAttatchment
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Byte[] File { get; set; }
        public Document Document { get; set; }
        public int DocumentID { get; set; }
        
    }
}
