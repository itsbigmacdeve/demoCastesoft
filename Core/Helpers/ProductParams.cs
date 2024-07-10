namespace Core.Helpers
{
    public class ProductParams
    {
        public const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        //Para el filtrado

        public string Brand { get; set; }

        public string Category { get; set; }

        //Para el ordenamiento

        public string orderBy { get; set; }


        
    }
}