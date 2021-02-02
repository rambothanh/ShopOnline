

namespace ShopOnline.API.Services.ImageService
{
    public interface IUploadImageService
    {
       void  ResizeImageAndRatio(
            string origFileLocation, 
            string newFileLocation, 
            string origFileName, 
            string newFileName, 
            int newWidth, 
            int newHeight);
        
    }
}