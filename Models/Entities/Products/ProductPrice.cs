using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class ProductPrice
    {
        //Set up one-to-zero-or-one relationship
        [ForeignKey("Product")]

        public int Id { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal SalePercent { get; set; }
        public virtual Product Product { get; set; }
        
        // SalePercent = Decimal.Round((CurrentPrice - OldPrice) / OldPrice * 100);

    }
}