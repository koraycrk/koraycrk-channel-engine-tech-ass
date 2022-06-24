using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChannelEngineAssessment.Web.Pages
{
    public class IndexModel : PageModel
    {
        

        public IndexModel()
        {
            
        }

        
        

        public async Task<IActionResult> OnGet()
        {
            
            return Page();
        }
    }
}
