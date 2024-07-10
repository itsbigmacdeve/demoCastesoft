using AutoMapper;
using Core.CoreDtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Helpers;
using Core.Extensions;


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
            var productExists = await _uow._productRepository.ProductExistsByNameAsync(createProductDto.Name);

            if (productExists) return BadRequest("Product already exists");

            if (createProductDto.Discount > 1 || createProductDto.Discount < 0) return BadRequest("Discount must be between 0 and 1");

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
        

        [HttpPut("update")]
        public async Task<ActionResult<ProductsDto>> UpdateProduct([FromBody]ProductsDto productDto)
        {
            var product = await _uow._productRepository.GetProductByIdAsync(productDto.Id);

            if (product == null) return NotFound();


            //Obtengo el id de la marca y la categoria
            var brandId = await _uow._productRepository.GetProductBrandByNameAsync(productDto.Brand);

            var categoryId = await _uow._productRepository.GetProductCategoryByNameAsync(productDto.Category);

            //Asigno los valores a las propiedades de la entidad
            product.ProductBrandId = brandId.Id;
            product.ProductCategoryId = categoryId.Id;

            
            // Mapear manualmente las propiedades restantes
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Discount = productDto.Discount;

            //Falta que se mapea automatico todo, ademas de para modificar la foto podriamos hacer un metodo para el front, que me traiga la lista de fotos y que cuando se quiera modificar se envie el id, de la foto y que lo que se mapee
            //sea el id recibido, pero buscando el id de la foto y que una vez conseguida la info de la foto se obtenga el url de esa foto y se le asigne a la entidad de producto

            var updatedProduct = await _uow._productRepository.UpdateProductAsync(product);

            var updatedProductDto = _mapper.Map<Products, ProductsDto>(updatedProduct);

            return Ok(updatedProductDto);
        }

        //Falta implementar el metodo para modificar las fotos

        [HttpGet("pagedProducts")]
        public async Task<PagedList<ProductsDto>> GetPagedProducts([FromQuery]ProductParams productsParams)
        {
            var products = await _uow._productRepository.GetPagedProductsAsync(productsParams);

            Response.AddPaginationHeader(new PaginationHeader(products.CurrentPage, products.PageSize, products.TotalCount, products.TotalPages));

            return products;
        }
    }
}