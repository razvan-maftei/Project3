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
    public class AddFileModel : PageModel
    {
        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        [BindProperty]
        public Models.FileDTO FileDTO { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        
        AddFileModel()
        {
            config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<ServiceReference1.FileDTO, Models.FileDTO>();
                cfg.CreateMap<Models.FileDTO, ServiceReference1.FileDTO>();
            });
            iMapper = config.CreateMapper();
            FileDTO = new Models.FileDTO();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var file = iMapper.Map<Models.FileDTO, ServiceReference1.FileDTO>(FileDTO);
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