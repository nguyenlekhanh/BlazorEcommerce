﻿using BlazorEcommerce.Shared;
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

        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public string Message { get; set; } = "Loading product...";

        public async Task GetProducts(string categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryUrl}");

            CurrentPage = 1;
            PageCount = 0;

            if (result is not null)
            {
                Products = result.Data;
                if(Products.Count == 0)
                {
                    Message = "No products found.";
                }
                ProductsChanged.Invoke();
            }            
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
            return result;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");
            Products = result.Data.Products;
            CurrentPage = result.Data.CurrentPage;
            PageCount = result.Data.Pages;

            if(Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchSuggestions/{searchText}");
            return result.Data;
        }
    }
}
