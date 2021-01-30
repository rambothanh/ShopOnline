using Models.Entities.Products;

namespace ShopOnline.API.Services.ProductService
{
    public interface IProductService
    {
        void UpdateProductPictureUri(int idProduct,string pictureUri =null);
        
    }
}