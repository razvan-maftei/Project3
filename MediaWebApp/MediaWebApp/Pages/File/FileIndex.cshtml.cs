using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;

namespace MediaWebApp.Pages.File
{
    public class FileIndexModel : PageModel
    {
        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        public List<Models.FileDTO> Files { get; set; }
        public FileIndexModel()
        {
            config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<ServiceReference1.FileDTO, Models.FileDTO>();
                cfg.CreateMap<Models.FileDTO, ServiceReference1.FileDTO>();
            });
            iMapper = config.CreateMapper();
            Files = new List<Models.FileDTO>();
        }
        public async Task OnGetAsync()
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            foreach(var item in files)
            {
                var fileDTO = iMapper.Map<ServiceReference1.FileDTO, Models.FileDTO>(item);
                Files.Add(fileDTO);
            }
        }
    }
}