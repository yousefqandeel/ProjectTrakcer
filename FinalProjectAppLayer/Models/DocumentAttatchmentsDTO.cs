using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class DocumentAttatchmentsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Byte[] File { get; set; }
        public int DocumentID { get; set; }
    }
}
