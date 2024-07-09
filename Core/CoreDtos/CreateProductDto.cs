namespace Core.CoreDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public int ProductCategoryId  { get; set; }
        public int ProductBrandId { get; set; }
        public List<CreateProductPhotoDto> Photos { get; set; }
    }
}