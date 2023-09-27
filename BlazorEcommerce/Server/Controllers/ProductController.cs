using BlazorEcommerce.Server.Controllers.Data;
using BlazorEcommerce.Server.Services.ProductService;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProductService _productService;

        public ProductController(DataContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var response = await _productService.GetProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductById(int id)
        {
            var response = await _productService.GetProductById(id);
            return Ok(response);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var response = await _productService.GetProductByCategory(categoryUrl);
            return Ok(response);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            var response = await _productService.SearchProducts(searchText, page);
            return Ok(response);
        }

        [HttpGet("searchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetProductSearchSuggestions(string searchText)
        {
            var response = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetFeaturedProducts()
        {
            var response = await _productService.GetFeaturedProducts();
            return Ok(response);
        }

        
    }
}
