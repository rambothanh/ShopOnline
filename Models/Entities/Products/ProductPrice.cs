using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class ProductPrice:IComparable<ProductPrice>
    {
        //Set up one-to-zero-or-one relationship
        [ForeignKey("Product")]

        public int Id { get; set; }
        public decimal CurrentPrice { get; set; } =0;
        public decimal OldPrice { get; set; } =0;
        public decimal SalePercent { get; set; }=0;
        public virtual Product Product { get; set; }

        public int CompareTo(ProductPrice other)
        {
            return this.CurrentPrice.CompareTo(other.CurrentPrice);
        }


        // SalePercent = Decimal.Round((CurrentPrice - OldPrice) / OldPrice * 100);

    }
}