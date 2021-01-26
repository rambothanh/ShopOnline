using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeRefId { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductBrand")]
        public int ProductBrandRefId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int Quantity { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }
    }
}