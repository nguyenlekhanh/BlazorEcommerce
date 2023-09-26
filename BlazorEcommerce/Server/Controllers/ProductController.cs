using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new BlazorEcommerce.Shared.Product
            {
                Id = 1,
                Title = "Lorem title 1",
                Description = "Description title",
                ImageUrl = "https://placehold.co/100",
                Price = 9.99M
            },
            new BlazorEcommerce.Shared.Product
            {
                Id = 2,
                Title = "Lorem title 2",
                Description = "Description title",
                ImageUrl = "https://placehold.co/100",
                Price = 7.99M
            },
            new BlazorEcommerce.Shared.Product
            {
                Id = 3,
                Title = "Lorem title 3",
                Description = "Description title",
                ImageUrl = "https://placehold.co/100",
                Price = 6.99M
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(Products);
        }
    }
}
