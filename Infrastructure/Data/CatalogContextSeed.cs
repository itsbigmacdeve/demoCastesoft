using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class CatalogContextSeed
    {
        //Lo que se hace aqui es que para cada uno de los json que tenemos se carga su informacion en la bd y posteriormente , si nota algun cambio en la bd se guarda
        public static async Task SeedAsync(CatalogDbContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                context.ProductBrands.AddRange(brands);
            }

            if(!context.ProductCategories.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                var types = JsonSerializer.Deserialize<List<ProductCategory>>(typesData);

                context.ProductCategories.AddRange(types);
            }

            if(!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Products>>(productsData);

                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}