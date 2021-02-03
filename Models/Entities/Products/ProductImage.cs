using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Entities.Products
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string PictureUri {get;set;}
        public bool IsMainPicture {get;set;}
        [ForeignKey("Product")]
        public int ProductRefId {get;set;}
        public Product Product { get; set; }
    }
}