using API.Dtos;
using AutoMapper;
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
    }
}