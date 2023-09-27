using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task GetProducts(string categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryUrl}");
            if(result is not null)
            {
                Products = result.Data;
                ProductsChanged.Invoke();
            }            
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
            return result;
        }
    }
}
