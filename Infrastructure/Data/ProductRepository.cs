using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.CoreDtos;

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
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<IReadOnlyList<ProductCategory>> GetProductCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p=> p.Photos).ToListAsync();
        }

        public Task<Products> UpdateProductAsync(Products product)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductsDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<CreateProductDto, Products>(createProductDto);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            // transform to ProductsDto

            var productDto = _mapper.Map<Products, ProductsDto>(product);

            return productDto;
        }
    }
}