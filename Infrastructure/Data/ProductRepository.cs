using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.CoreDtos;
using Core.Helpers;
using AutoMapper.QueryableExtensions;

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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductBrand> GetProductBrandByNameAsync(string name)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(p => p.Name == name);
        }


        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IReadOnlyList<ProductCategory>> GetProductCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductCategory> GetProductCategoryByNameAsync(string name)
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p=> p.Photos).ToListAsync();
        }

        public async Task<Products> UpdateProductAsync(Products product) // Modifica todo menos las fotos
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<ProductsDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            //Obtenro el producto a partir del Dto, ya como Products
            var product = _mapper.Map<CreateProductDto, Products>(createProductDto);

            _context.Products.Add(product);

            //Se agrega el producto a la base de datos
            await _context.SaveChangesAsync();

            //Se obtiene el producto de la base de datos
            product = GetProductByIdAsync(product.Id).Result;

            var productDto = _mapper.Map<Products, ProductsDto>(product);

            return productDto;
        }

        public Task<Products> UpdateProductPhotosAsync(Products product) // Aqui se podria modificar las fotos
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProductExistsByNameAsync(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name); 
        }

        //Metodos con paginacion//


        //Este era con la pura paginacion
        /* public async Task<PagedList<ProductsDto>> GetPagedProductsAsync(ProductParams productParams)
        {
            var query = _context.Products
                .ProjectTo<ProductsDto>(_mapper.ConfigurationProvider)
                .AsNoTracking();

            return await PagedList<ProductsDto>.CreateAsync(query, productParams.PageNumber, productParams.PageSize);
        } */

        //Este es con la paginacion y el filtrado tener cuidado cuando este un all
        public async Task<PagedList<ProductsDto>> GetPagedProductsAsync(ProductParams productParams)
        {
            var query = _context.Products.AsQueryable();

            //Aqui se podria agregar el filtrado
            if(!string.IsNullOrEmpty(productParams.Brand))
            {
                query = query.Where(p => p.Brand.Name == productParams.Brand);
            }
            
            if(!string.IsNullOrEmpty(productParams.Category))
            {
                query = query.Where(p => p.Category.Name == productParams.Category);
            }

            //Aqui se podria agregar el ordenamiento

            switch (productParams.orderBy)
            {
                case "priceAsc":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }
            

            return await PagedList<ProductsDto>.CreateAsync(query.AsNoTracking().ProjectTo<ProductsDto>(_mapper.ConfigurationProvider), productParams.PageNumber, productParams.PageSize);
        }

    }
}