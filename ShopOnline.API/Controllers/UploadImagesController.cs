using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Products;
using ShopOnline.API.Models;
using ShopOnline.API.Services.ProductService;
using ShopOnline.API.Services.ImageService;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly ShopOnlineContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IProductService _productService;
        private readonly IUploadImageService _uploadImageService;


        public UploadImageController(ShopOnlineContext context,
        IWebHostEnvironment env,
        IProductService productService,
        IUploadImageService uploadImageService)
        {
            _context = context;
            _env = env;
            _productService = productService;
            _uploadImageService = uploadImageService;
        }



        // GET: api/UploadImage
        [HttpGet("{idProduct}")]
        public async Task<ActionResult<IEnumerable<ProductImage>>> GetProductImages(int idProduct)
        {
            return await _context.ProductImages.Where(x => x.ProductRefId == idProduct).ToListAsync();
        }


        // POST: api/UploadImage
        [HttpPost]
        public async Task Post(UploadImage uploadImage)
        {
            //rootPath =  ~\\assets\\images\\product\\ ;
            var rootPath = GetRootDirectoryOfWebRP();

            // Đường dẫn lưu ảnh tạm trước khi crop
            var pathTemp = Path.Combine(rootPath, "Temp");
            //Path save MainImage
            var pathMain384x480 = Path.Combine(rootPath, "Main384x480");
            //Folder Single720x900
            var pathSingle720x900 = Path.Combine(rootPath, "Single720x900");
            //Change file name
            string newName = RenameFile(uploadImage.FileName, $"{uploadImage.ProductId.ToString()}-{Guid.NewGuid()}");// fileName: Id-Guid
            // Creates or overwrites a file in the specified path.
            var fs = System.IO.File.Create(Path.Combine(pathTemp, newName));
            //var fs = System.IO.File.Create($"{pathTemp}\\{newName}");

            // Write content byte[] type into file image has just create. 
            fs.Write(uploadImage.FileContent, 0, uploadImage.FileContent.Length);
            fs.Close();

            //Crop and resize image width x height 720x900
            //And save file to pathSingle720x900
            _uploadImageService.ResizeImageAndRatio(
                pathTemp,
                pathSingle720x900,
                newName,
                newName,
                720,
                900);

            //Create ProductImage
            //Because export to web. Should use / , don't use \
            ProductImage productImage720x900 = new ProductImage()
            {
                PictureUri = $"assets/images/product/Single720x900/{newName}",
                ProductRefId = uploadImage.ProductId,
                IsMainPicture = false
            };
            //Save new product on database
            _productService.CreateProductPictureUri(productImage720x900);

            //If IsMainImage --> Crop a image 384x480
            if (uploadImage.IsMainImage)
            {
                _uploadImageService.ResizeImageAndRatio(
                pathTemp,
                pathMain384x480,
                newName,
                newName,
                384,
                480);

                //Create ProductImage
                ProductImage productImage384x480 = new ProductImage()
                {
                    PictureUri = $"assets/images/product/Main384x480/{newName}",
                    ProductRefId = uploadImage.ProductId,
                    IsMainPicture = true
                };
                //Create new product on database
                _productService.CreateProductPictureUri(productImage384x480);
            }
            //Check and Create Main Image
            await CheckAndDeleteOneImage(uploadImage.ProductId);
            await CheckMainPicture(uploadImage.ProductId);

            //----------Delete temp image -------------
            DeleteFile(pathTemp, newName);
        }

        // DELETE: api/UploadImage/5
        [HttpDelete("{idProduct}")]
        // Check if Image in Product >=5 will delete one or more
        public async Task<IActionResult> DeleteAllImage(int idProduct)
        {
            var productImages = await _context.ProductImages.Where(x => x.ProductRefId == idProduct).ToListAsync();
            //If null or empty
            if (productImages?.Any() != true)
            {
                return NoContent();
            }
            foreach (var productImage in productImages)
            {
                await DeleteImage(productImage.Id);
                _context.ProductImages.Remove(productImage);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        //Check if a product has more than 5 image and delete
        private async Task CheckAndDeleteOneImage(int idProduct)
        {
            var productImages = await _context.ProductImages.Where(x => x.ProductRefId == idProduct).ToListAsync();

            //If null or empty
            if (productImages?.Any() != true)
            {
                return;
            }

            //OrderBy Id
            productImages = productImages.OrderBy(x => x.Id).ToList();

            //if Exist more than 5 picture
            var countDelete = productImages.Count() - 5;

            if (countDelete > 0)
            {
                for (var i = 1; i <= countDelete; i++)
                {
                    //Delete Image in folder server with oldest Id
                    await DeleteImage((productImages.ElementAt(i - 1)).Id);
                    //Delete record ProductImage in database
                    _context.ProductImages.Remove(productImages.ElementAt(i - 1));
                    await _context.SaveChangesAsync();
                }
            }

        }

        //// Check if Image in Product has a MainPicture
        // If existed main : return
        // If hasn't exited yet : create one from newest Image
        private async Task CheckMainPicture(int idProduct)
        {

            var productImages = await _context.ProductImages.Where(x => x.ProductRefId == idProduct).ToListAsync();
            //If null or empty
            if (productImages?.Any() != true)
            {
                return;
            }
            productImages = productImages.OrderByDescending(x => x.Id).ToList();
            var rootPath = GetRootDirectoryOfWebRP();
            var pathMain384x480 = Path.Combine(rootPath, "Main384x480");
            //var pathMain384x480 = $"{rootPath}\\assets\\images\\product\\Main384x480";
            //Check each productImage if its is mainImage
            var countMainImage = 0;
            foreach (var productImage in productImages)
            {
                // //Get file name
                // string fileName = Path.GetFileName(productImage.PictureUri);
                // //Search in folder Main384x480
                // string[] picList = Directory.GetFiles(pathMain384x480, fileName);
                // If mainImage 
                if (productImage.IsMainPicture) countMainImage++;
                if (countMainImage > 1)
                {
                    //Delete Image in folder server with oldest Id
                    await DeleteImage(productImage.Id);
                    //Remove Image on database
                    _context.ProductImages.Remove(productImage);
                }
            }

            if (countMainImage == 1) return;
            //--------------Create MainImage by Newest Id ProductImage----------
            //productImages = productImages.OrderByDescending(x => x.Id).ToList();
            string fileNameAdd = Path.GetFileName(productImages.ElementAt(0).PictureUri);
            var pathSingle720x900 = Path.Combine(rootPath, "Single720x900");
            //var pathSingle720x900 = $"{rootPath}\\assets\\images\\product\\Single720x900";

            string newName384x480 = RenameFile(fileNameAdd, $"{idProduct.ToString()}-{Guid.NewGuid()}"); // fileName: Id-Guid, 
            _uploadImageService.ResizeImageAndRatio(
                pathSingle720x900,
                pathMain384x480,
                fileNameAdd,
                newName384x480,
                384,
                480);

            //Create ProductImage
            ProductImage productImage384x480 = new ProductImage()
            {
                PictureUri = $"assets/images/product/Main384x480/{newName384x480}",
                ProductRefId = idProduct,
                IsMainPicture = true
            };
            //Create new product on database
            _productService.CreateProductPictureUri(productImage384x480);
            //Check and delete image Product
            await CheckAndDeleteOneImage(idProduct);
        }

        // Delete image in folder server by idProductImage 
        private async Task DeleteImage(int idProductImage)
        {
            var rootPath = GetRootDirectoryOfWebRP();
            //Path save MainImage
            var pathMain384x480 = Path.Combine(rootPath, "Main384x480");
            //var pathMain384x480 = rootPath + @"\assets\images\product\Main384x480";
            //Folder Single720x900
            var pathSingle720x900 = Path.Combine(rootPath, "Single720x900");
            //var pathSingle720x900 = rootPath + @"\assets\images\product\Single720x900";

            //Get pictureUri like: assets/images/product/130-c75f797d-dd4a-4da3-b89d-6971b52b83fe.jpg
            var productImage = await _context.ProductImages.FindAsync(idProductImage);
            var pictureUri = productImage.PictureUri;

            //Null or Empty: do nothing
            if (String.IsNullOrEmpty(pictureUri))
                return;

            //Lấy tên file bao gồm phần mở rộng
            string fileName = Path.GetFileName(pictureUri);

            //Delete
            DeleteFile(pathMain384x480, fileName);
            DeleteFile(pathSingle720x900, fileName);
        }

        //Delete file in folder
        private void DeleteFile(string path, string fileName)
        {
            string[] picList = Directory.GetFiles(path, fileName);
            if (!(picList?.Length > 0))
            {
                // Null or empty: do nothing 
            }
            else
            {
                //Delete
                foreach (string f in picList)
                {
                    System.IO.File.Delete(f);
                }
            }
        }

        //Rename exclude extenstion
        private string RenameFile(string pathOriFile, string newName)
        {
            // ---------Đổi tên file-----------
            // Lấy tên file cũ, không bao gồm phần mở rộng
            string oldName = Path.GetFileNameWithoutExtension(pathOriFile);
            //Replace phần oldName bên trong pathOriFile thành newName
            return pathOriFile.Replace(oldName, newName);

        }

        //Get Directory: ...ShopOnline\
        //Config this function when Deploy Unbuntu
        //Get Folder "product" contain image of Product
        private string GetRootDirectoryOfWebRP()
        {
            #region root in Development Window

            // // Link như vầy không có tác dụng với Linux:
            // // Vì có file dll bên trong, nhưng window thì được,
            // // Làm xảy ra lỗi tìm mấy ngày
            // // ~/publish/ShopOnline.API.dll/.. <-- Không có tác dụng lùi vào Parent folder trên Linux
            // //rootDir là ~ShopOnline/ShopOnline.API/bin/Debug/net5.0/publish
            // var rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            // rootDir = Path.Combine(rootDir, "..");
            // rootDir = Path.Combine(rootDir, "..");
            // rootDir = Path.Combine(rootDir, "..");
            // rootDir = Path.Combine(rootDir, "..");
            // rootDir = Path.Combine(rootDir, ".."); // parent 5 level
            // // Trên linux, Folder file tĩnh khui publish nằm ở /ShopOnline/WebRP/wwwroot
            // // Không phải như ở Window, nằm ở: /ShopOnline/WebRP/bin/Debug/net5.0/publish/wwwroot
            // //ShopOnline/WebRP/bin/Debug/net5.0/publish/wwwroot/assets/images/product\
            // rootDir = Path.Combine(rootDir, "WebRP");
            // rootDir = Path.Combine(rootDir, "bin");
            // rootDir = Path.Combine(rootDir, "Debug");
            // rootDir = Path.Combine(rootDir, "net5.0");
            // rootDir = Path.Combine(rootDir, "publish");
            // rootDir = Path.Combine(rootDir, "wwwroot");
            // rootDir = Path.Combine(rootDir, "assets");
            // rootDir = Path.Combine(rootDir, "images");
            // rootDir = Path.Combine(rootDir, "product");

            #endregion

            #region root in Production Unbuntu

            // Link như vầy không có tác dụng với Linux:
            // Vì có file dll bên trong, nhưng window thì được,
            // Làm xảy ra lỗi tìm mấy ngày
            // ~/publish/ShopOnline.API.dll/.. <-- Không có tác dụng lùi vào Parent folder trên Linux
            //rootDir là ~ShopOnline/ShopOnline.API/bin/Debug/net5.0/publish
            var rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            rootDir = Path.Combine(rootDir, "..");
            rootDir = Path.Combine(rootDir, "..");
            rootDir = Path.Combine(rootDir, "..");
            rootDir = Path.Combine(rootDir, "..");
            rootDir = Path.Combine(rootDir, ".."); // parent 5 level
            // Trên linux, Folder file tĩnh khui publish nằm ở /ShopOnline/WebRP/wwwroot
            // Không phải như ở Window, nằm ở: /ShopOnline/WebRP/bin/Debug/net5.0/publish/wwwroot
            //ShopOnline/WebRP/bin/Debug/net5.0/publish/wwwroot/assets/images/product\
            rootDir = Path.Combine(rootDir, "WebRP");
            rootDir = Path.Combine(rootDir, "wwwroot");
            rootDir = Path.Combine(rootDir, "assets");
            rootDir = Path.Combine(rootDir, "images");
            rootDir = Path.Combine(rootDir, "product");
            return rootDir;
            #endregion 
        }

    }//end class UploadImageController
}//end namespace ShopOnline.API.Controllers