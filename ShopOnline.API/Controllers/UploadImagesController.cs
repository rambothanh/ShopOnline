using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Products;
using ShopOnline.API.Models;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly ShopOnlineContext _context;
        private readonly IWebHostEnvironment _env;


        public UploadImageController(ShopOnlineContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // POST: api/UploadImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void Post(UploadImage uploadImage)
        {
            //Đường dẫn lưu ảnh
            //var path = $"{_env.WebRootPath}\\{uploadImage.FileName}";
            var pathInCompany = @"D:\Soft\Project\My Git Project\ShopOnline\WebRP\wwwroot\assets\images\product";
            var path = $"{pathInCompany}\\{uploadImage.FileName}";
            //Creates or overwrites a file in the specified path.
            var fs = System.IO.File.Create(path);
            //Viết nội dung dạng byte[] vào file ảnh vừa tạo. 
            fs.Write(uploadImage.FileContent, 0, uploadImage.FileContent.Length);
            fs.Close();
        }

    }
}
