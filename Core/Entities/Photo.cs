namespace Core.Entities
{
    public class Photo :BaseEntity
    {
        public string Url { get; set; }

        public bool IsMain { get; set; }
    
        // Se agrega para poder relacionar la foto con el producto
        public int ProductPhotoId { get; set; }
    }
}