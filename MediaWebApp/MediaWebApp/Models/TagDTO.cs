using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWebApp.Models
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int FileId { get; set; }
        public virtual FileDTO File { get; set; }
    }
}
