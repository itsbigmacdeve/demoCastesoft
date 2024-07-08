using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(CatalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
        
        }

        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public Task<IReadOnlyList<ProductCategory>> GetProductCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Products> UpdateProductAsync(Products product)
        {
            throw new NotImplementedException();
        }
    }
}