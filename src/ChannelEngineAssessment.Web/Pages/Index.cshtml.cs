using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessment.Web.Interfaces;
using ChannelEngineAssessment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChannelEngineAssessment.Web.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IIndexPageService _indexPageService;

        public IndexModel(IIndexPageService indexPageService)
        {
            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGet()
        {
            
            
            
            
            return Page();
        }
    }
}
