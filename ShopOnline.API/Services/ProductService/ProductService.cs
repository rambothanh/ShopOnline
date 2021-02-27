using ShopOnline.API.Models;
using ShopOnline.API.Models.Helpers;
using Models.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Models.Infrastructure;
using System.Linq;

namespace ShopOnline.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        private ShopOnlineContext _context;
        private ISortHelper<Product> _sortHelper;

        public ProductService(ShopOnlineContext context, ISortHelper<Product> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }

        public PagedList<Product> GetProducts(ProductParameters productParameters)
        {
            var products = FindAllProducts();
            SearchByName(ref products, productParameters.ProductName);
            products = _sortHelper.ApplySort(products, productParameters.OrderBy);
            //SQLite không sắp xếp được Decimal
            //products = products.OrderBy(p => p.ProductPrice.CurrentPrice);
            
            return PagedList<Product>.ToPagedList(products,
                productParameters.PageNumber,
                productParameters.PageSize);
        }
        public void CreateProductPictureUri(ProductImage paraProductImage)
        {
            _context.ProductImages.Add(paraProductImage);
            _context.SaveChanges();
        }

        public void UpdateProductPictureUri(int idProductImage, ProductImage paraProductImage)
        {
            if (idProductImage != paraProductImage.Id)
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

        public void UpdateProduct(int idProduct, Product productPara)
        {
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
            if (productPara.ProductBrandRefId != 0)
                product.ProductBrandRefId = productPara.ProductBrandRefId;
            if (productPara.ProductTypeRefId != 0)
                product.ProductTypeRefId = productPara.ProductTypeRefId;
            if (!string.IsNullOrWhiteSpace(productPara.Description))
                product.Description = productPara.Description;
            if (!string.IsNullOrWhiteSpace(productPara.ShortDescription))
                product.ShortDescription = productPara.ShortDescription;
            // if (!string.IsNullOrWhiteSpace(productPara.PictureUri))
            //     product.PictureUri = productPara.PictureUri;
            if (productPara.Quantity != 0)
                product.Quantity = productPara.Quantity;
            // if (productPara.ProductPrice.CurrentPrice!= 0)
            //     product.ProductPrice.CurrentPrice = productPara.ProductPrice.CurrentPrice;
            // if (productPara.ProductPrice.OldPrice!= 0)
            //     product.ProductPrice.OldPrice = productPara.ProductPrice.OldPrice;

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IQueryable<Product> FindAllProducts()
        {
            return _context.Products.Include(x => x.ProductPrice)
                                    .Include(x => x.ProductBrand)
                                    .Include(x => x.ProductType)
                                    .Include(x => x.ProductImages)
                                    .AsSplitQuery()
                                    .AsNoTracking();
        }
        private void SearchByName(ref IQueryable<Product> products, string productName = null)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return;

            products = products.Where(p => p.Name.ToLower().Contains(productName.Trim().ToLower()));
        }
    }
}