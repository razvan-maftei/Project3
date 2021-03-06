﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;

namespace MediaWebApp.Pages.File
{
    public class AddFileModel : PageModel
    {
        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        [BindProperty]
        public Models.FileDTO FileDTO { get; set; }
        public List<string> TagKeys { get; set; }

        public AddFileModel()
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
            TagKeys = new List<string>();
        }

        public async Task OnGetAsync()
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            foreach (var file in files)
            {
                foreach (var tag in file.Tags)
                {
                    this.TagKeys.Add(tag.Key);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var file = iMapper.Map<Models.FileDTO, ServiceReference1.FileDTO>(FileDTO);
            var Metadata = new Models.MetadataDTO();
            Metadata.CreationDate = DateTime.Now;
            file.Metadata = iMapper.Map<Models.MetadataDTO, ServiceReference1.MetadataDTO>(Metadata);
            file.Tags = new List<ServiceReference1.TagDTO>().ToArray();
            try
            {
                await pcc.AddFileAsync(file);
            } catch(Exception e)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("./Index");
        }
    }
}