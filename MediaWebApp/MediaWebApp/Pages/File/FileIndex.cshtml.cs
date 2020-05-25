using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference1;

namespace MediaWebApp.Pages.File
{
    public class FileIndexModel : PageModel
    {
        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        public List<Models.FileDTO> Files { get; set; }
        public Dictionary<int, string> pathMapper { get; set; }
        public SelectList TagKeys { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Key { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Value { get; set; }
        public FileIndexModel()
        {
            pathMapper = new Dictionary<int, string>();
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
            Files = new List<Models.FileDTO>();
        }
        public async Task<IActionResult> OnGetAsync(string? Key, string? Value)
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            var fileList = new List<Models.FileDTO>();

            foreach(var file in files)
            {
                var b64 = GetBase64(file.Path);
                if (fileList.Any(f => f.Path == b64))
                {
                    var f = fileList.Find(f => f.Path == b64);
                    if (file.Tags.Length > 0)
                    {
                        foreach (var tag in file.Tags)
                        {
                            f.Tags.Add(iMapper.Map<ServiceReference1.TagDTO, Models.TagDTO>(tag));
                        }
                    }
                } else
                {
                    if (file.Path.Length > 0 && !file.IsDeleted)
                    {
                        var newFile = new Models.FileDTO();
                        newFile.Metadata = new Models.MetadataDTO();
                        newFile.Metadata.CreationDate = file.Metadata.CreationDate;
                        newFile.Path = GetBase64(file.Path);
                        newFile.Tags = new List<Models.TagDTO>();
                        newFile.Id = file.Id;
                        fileList.Add(newFile);
                        pathMapper.Add(file.Id, file.Path);
                    }
                }
            }

            var Keys = new List<string>();
            foreach (var file in fileList)
            {
                foreach(var tag in file.Tags)
                {
                    Keys.Add(tag.Key);
                }
            }
            TagKeys = new SelectList(Keys.Distinct().ToList());
            if (Key == null)
            {
                Files = fileList;
            }
            else if (Key != null && Value != null)
            {
                Files = fileList.Where(f => f.Tags.Any(t => t.Key == Key && t.Value == Value)).ToList();
            }
            return Page();
        }
        public string GetBase64(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(@imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return "data:image/png;base64," + base64String;
        }
    }
}