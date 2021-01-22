using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        [ForeignKey("Type")]
        public int TypeRefId { get; set; }
        public Type Type { get; set; }
        [ForeignKey("Brand")]
        public int BrandRefId { get; set; }
        public Brand Brand { get; set; }
    }
}