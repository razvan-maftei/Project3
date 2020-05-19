using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWebApp.Models
{
    public class FileDTO
    {
        public FileDTO()
        {
            this.Tags = new HashSet<TagDTO>();
        }
        public int Id { get; set; }
        public string Path { get; set; }
        public bool IsDeleted { get; set; }
        public virtual MetadataDTO Metadata { get; set; }
        public virtual ICollection<TagDTO> Tags { get; set; }
    }
}
