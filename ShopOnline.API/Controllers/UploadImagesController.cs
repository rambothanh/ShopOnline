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

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly ShopOnlineContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IProductService _productService;


        public UploadImageController(ShopOnlineContext context, 
        IWebHostEnvironment env,
        IProductService productService)
        {
            _context = context;
            _env = env;
            _productService = productService;
        }
        // POST: api/UploadImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void Post(UploadImage uploadImage)
        {
            // Đường dẫn lưu ảnh
            // var path = $"{_env.WebRootPath}\\{uploadImage.FileName}";
            var pathInCompany = @"D:\Soft\Project\My Git Project\ShopOnline\WebRP\wwwroot\assets\images\product";

            // ---------Đổi tên file-----------
            // Lấy tên file cũ, không bao gồm phần mở rộng
            string oldName = Path.GetFileNameWithoutExtension(uploadImage.FileName);
            // Tạo tên file mới bằng cách replace phần tên cũ với phần tên mới
            // DateTime.Now.Ticks để tạo số Tick ngày giờ hiện tại
            // Chuyển qua dùng Guid.NewGuid() cho chắc ăn, tránh trùng lập
            string newName = uploadImage.FileName.Replace(oldName, $"{uploadImage.ProductId.ToString()}-{Guid.NewGuid()}");
            //{new DateTime().Ticks}
            //đường dẫn lưu file
            var path = $"{pathInCompany}\\{newName}";
            // Creates or overwrites a file in the specified path.
            var fs = System.IO.File.Create(path);
            // Viết nội dung dạng byte[] vào file ảnh vừa tạo. 
            fs.Write(uploadImage.FileContent, 0, uploadImage.FileContent.Length);

            fs.Close();
            //var productsController = DependencyResolver.Current.GetService<productsController>();
            Product product = new Product(){
                Id = uploadImage.ProductId,
                PictureUri = path 
            };
            //Add PictureUri to Product
            _productService.UpdateProductPictureUri(uploadImage.ProductId,$"assets/images/product/{newName}");
            //ProductsController productsController = new ProductsController(_context);
            //await productsController.PutProduct(uploadImage.ProductId,product);

        }

        // DELETE: api/UploadImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
