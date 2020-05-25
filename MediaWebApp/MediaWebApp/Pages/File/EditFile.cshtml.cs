using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;

namespace MediaWebApp.Pages.File
{
    public class EditFileModel : PageModel
    {
        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Models.FileDTO FileDTO { get; set; }
        public List<string> TagKeys { get; set; }
        [BindProperty]
        public string TagKey1 { get; set; }
        [BindProperty]
        public string TagValue1 { get; set; }
 
        public EditFileModel()
        {
            config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<ServiceReference1.FileDTO, Models.FileDTO>();
                cfg.CreateMap<Models.FileDTO, ServiceReference1.FileDTO>();
                cfg.CreateMap<ServiceReference1.MetadataDTO, Models.MetadataDTO>();
                cfg.CreateMap<Models.MetadataDTO, ServiceReference1.MetadataDTO>();
                cfg.CreateMap<ServiceReference1.TagDTO, Models.TagDTO>();
                cfg.CreateMap<Models.TagDTO, ServiceReference1.TagDTO>();
            });
            iMapper = config.CreateMapper();
            FileDTO = new Models.FileDTO();
            TagKey1 = "";
            TagValue1 = "";
        }
        public async Task OnGetAsync()
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            var OriginalFile = files.First(f => f.Id == Id);
            FileDTO = iMapper.Map<ServiceReference1.FileDTO, Models.FileDTO>(OriginalFile);
            var MetadataDTO = new Models.MetadataDTO();
            MetadataDTO = iMapper.Map<ServiceReference1.MetadataDTO, Models.MetadataDTO>(OriginalFile.Metadata);
            var Tags = new List<Models.TagDTO>();
            foreach (var tag in OriginalFile.Tags)
            {
                Tags.Add(iMapper.Map<ServiceReference1.TagDTO, Models.TagDTO>(tag));
            }
            FileDTO.Metadata = MetadataDTO;
            FileDTO.Tags = Tags;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            var OriginalFile = files.First(f => f.Id == Id);

            var Tag = new ServiceReference1.TagDTO
            {
                Key = TagKey1,
                Value = TagValue1
            };

            Tag.File = OriginalFile;
            Tag.FileId = OriginalFile.Id;

            try
            {
                await pcc.AddTagAsync(Tag);
            } catch (Exception e)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("./Index");
        }
    }
}