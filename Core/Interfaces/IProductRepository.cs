
using Core.CoreDtos;
using Core.Entities;



namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Products>GetProductByIdAsync(int id);

        Task<IReadOnlyList<Products>>GetProductsAsync();

        void DeleteProduct(Products product);

        Task<Products>UpdateProductAsync(Products product); //Modifica todo menos las fotos

        //Metodo para modificar las fotos

        Task<Products>UpdateProductPhotosAsync(Products product);

        Task<IReadOnlyList<ProductBrand>>GetProductBrandsAsync();

        Task<ProductBrand> GetProductBrandByIdAsync(int id);

        Task<ProductBrand> GetProductBrandByNameAsync(string name);

        Task<IReadOnlyList<ProductCategory>>GetProductCategoriesAsync();

        Task<ProductCategory> GetProductCategoryByIdAsync(int id);

        Task<ProductCategory> GetProductCategoryByNameAsync(string name);

        Task<ProductsDto>CreateProductAsync(CreateProductDto createProductDto);

        Task<bool> ProductExistsByNameAsync(string name);


    }
}