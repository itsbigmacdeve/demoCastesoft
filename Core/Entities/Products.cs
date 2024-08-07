namespace Core.Entities
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public ProductCategory Category  { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductBrand Brand { get; set; }

        public int ProductBrandId { get; set; }
        public List<Photo> Photos { get; set; }

        
    }
}