using ShopOnline.API.Models;
using ShopOnline.API.Models.Helpers;
using Models.Entities.Products;
using Microsoft.EntityFrameworkCore;

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
        public  void UpdateProduct(int idProduct, Product productPara ){
            if (idProduct != productPara.Id)
            {
                throw new AppException("Wrong id Product");
            }
            var product = _context.Products.Find(idProduct);

            if (product == null)
                throw new AppException("Product not found");

            // update product properties if provided
            if (!string.IsNullOrWhiteSpace(productPara.Name))
                product.Name = productPara.Name;
            if (productPara.ProductBrandRefId!= 0)
                product.ProductBrandRefId = productPara.ProductBrandRefId;
            if (productPara.ProductTypeRefId!= 0)
                product.ProductTypeRefId = productPara.ProductTypeRefId;
            if (!string.IsNullOrWhiteSpace(productPara.Description))
                product.Description = productPara.Description;
            if (!string.IsNullOrWhiteSpace(productPara.ShortDescription))
                product.ShortDescription = productPara.ShortDescription;
            if (!string.IsNullOrWhiteSpace(productPara.PictureUri))
                product.PictureUri = productPara.PictureUri;
            if (productPara.Quantity!= 0)
                product.Quantity = productPara.Quantity;
            // if (productPara.ProductPrice.CurrentPrice!= 0)
            //     product.ProductPrice.CurrentPrice = productPara.ProductPrice.CurrentPrice;
            // if (productPara.ProductPrice.OldPrice!= 0)
            //     product.ProductPrice.OldPrice = productPara.ProductPrice.OldPrice;

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}