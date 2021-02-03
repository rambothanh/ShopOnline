using Models.Entities.Products;

namespace ShopOnline.API.Services.ProductService
{
    public interface IProductService
    {
        void CreateProductPictureUri(ProductImage paraProductImage);
        void UpdateProductPictureUri(int idProductImage, ProductImage paraProductImage);
        void UpdateProduct (int idProduct, Product product);
        
    }
}