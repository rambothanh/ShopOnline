namespace Models.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUri { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}