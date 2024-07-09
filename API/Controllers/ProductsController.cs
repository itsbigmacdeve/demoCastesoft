using AutoMapper;
using Core.CoreDtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductsDto>>> GetProducts()
        {
            var products = await _uow._productRepository.GetProductsAsync();

            var productsDto = _mapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProductsDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProduct(int id)
        {
            var product = await _uow._productRepository.GetProductByIdAsync(id);

            var productDto = _mapper.Map<Products, ProductsDto>(product);
            
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _uow._productRepository.GetProductByIdAsync(id);

            if (product == null) return NotFound();
            _uow._productRepository.DeleteProduct(product);
            if(await _uow.Complete()) return Ok();
            
            return BadRequest("Problem deleting the product");
        }


        [HttpPost]
        public async Task<ActionResult<ProductsDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var productDto = await _uow._productRepository.CreateProductAsync(createProductDto);

            if (productDto == null) return BadRequest("Problem creating product");

            return Ok(productDto);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _uow._productRepository.GetProductBrandsAsync();

            return Ok(productBrands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetProductCategories()
        {
            var productCategories = await _uow._productRepository.GetProductCategoriesAsync();

            return Ok(productCategories);
        }

        
    }
}