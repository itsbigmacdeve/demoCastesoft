namespace Core.CoreDtos
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Category  { get; set; }
        public string Brand { get; set; }
        public string PictureUrl { get; set; }
    }
}