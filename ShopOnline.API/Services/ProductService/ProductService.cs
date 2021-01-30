using ShopOnline.API.Models;
using ShopOnline.API.Models.Helpers;

namespace ShopOnline.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        private ShopOnlineContext _context;

        public ProductService(ShopOnlineContext context)
        {
            _context = context;
        }

        public void UpdateProductPictureUri(int idProduct, string pictureUri = null)
        {
            var product = _context.Products.Find(idProduct);

            if (product == null)
                throw new AppException("Product not found");
            
            // update product properties if provided
            if (!string.IsNullOrWhiteSpace(pictureUri))
                product.PictureUri = pictureUri;

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}