﻿using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();

        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);

        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);

        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);

        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
