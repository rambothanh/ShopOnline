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

        
        public void CreateProductPictureUri(ProductImage paraProductImage){
            _context.ProductImages.Add(paraProductImage);
            _context.SaveChanges();
        }

        public void UpdateProductPictureUri(int idProductImage, ProductImage paraProductImage)
        {
            if(idProductImage != paraProductImage.Id)
                throw new AppException("Bad Request");

            //Lấy productImage ra
            var productImage = _context.ProductImages.Find(idProductImage);

            if (productImage == null)
                throw new AppException("Image not found");
            
            // update productImage properties if provided
            if (!string.IsNullOrWhiteSpace(paraProductImage.PictureUri))
                productImage.PictureUri = paraProductImage.PictureUri;

            _context.ProductImages.Update(productImage);
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
            // if (!string.IsNullOrWhiteSpace(productPara.PictureUri))
            //     product.PictureUri = productPara.PictureUri;
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