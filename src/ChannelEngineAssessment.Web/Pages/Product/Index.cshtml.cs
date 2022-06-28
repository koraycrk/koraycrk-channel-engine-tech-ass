using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessment.Web.Interfaces;
using ChannelEngineAssessment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChannelEngineAssessment.Web.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public IndexModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productPageService.GetProducts("IN_PROGRESS");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            try
            {
                await _productPageService.UpdateProdctStock(25, Product.StockLocationId, Product.MerchantProductNo);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToPage("/Index");
        }
    }
}
