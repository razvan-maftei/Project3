using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWebApp.Models
{
    public class MetadataDTO
    {
        public int Id { get; set; }
        public System.DateTime CreationDate { get; set; }
        public virtual FileDTO File { get; set; }
    }
}
