using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;

namespace MediaWebApp.Pages.File
{
    public class DeleteFileModel : PageModel
    {
        FileMetadataTagClient pcc = new FileMetadataTagClient();
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var files = await pcc.GetFilesAndMetadataAsync();
            var file = files.First(f => f.Id == Id);
            try
            {
                await pcc.DeleteFileAsync(file.Path);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("./Index");
        }
    }
}