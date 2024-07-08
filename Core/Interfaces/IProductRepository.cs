using Core.Entities;


namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Products>GetProductByIdAsync(int id);

        Task<IReadOnlyList<Products>>GetProductsAsync();

        void DeleteProduct(Products product);

        Task<Products>UpdateProductAsync(Products product);

        Task<IReadOnlyList<ProductBrand>>GetProductBrandsAsync();

        Task<IReadOnlyList<ProductCategory>>GetProductCategoriesAsync();

    }
}