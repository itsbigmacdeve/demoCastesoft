namespace Core.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public int CategoryId  { get; set; }
        public int BrandId { get; set; }
        public List<CreateProductPhotoDto> Photos { get; set; }
    }
}