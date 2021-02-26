using Models.Entities.Products;
using Models.Infrastructure;

namespace ShopOnline.API.Services.ProductService
{
    public interface IProductService
    {
        PagedList<Product> GetProducts(ProductParameters productParameters);
        void CreateProductPictureUri(ProductImage paraProductImage);
        void UpdateProductPictureUri(int idProductImage, ProductImage paraProductImage);
        void UpdateProduct(int idProduct, Product product);

    }
}