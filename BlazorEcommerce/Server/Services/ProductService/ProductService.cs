﻿using BlazorEcommerce.Server.Controllers.Data;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>
            {
                Data = products
            };

            return response;
        }
    }
}
