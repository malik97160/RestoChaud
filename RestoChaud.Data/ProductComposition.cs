using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoChaud.Data
{
    public class ProductComposition
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int ComponentId { get; set; }
        [Column(TypeName = "decimal(10, 3)")]
        public decimal? Quantity { get; set; }

        [ForeignKey(nameof(ComponentId))]
        [InverseProperty(nameof(Data.Product.ProductCompositionsComponent))]
        public virtual Product Component { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Data.Product.ProductCompositionsProduct))]
        public virtual Product Product { get; set; }
    }
}
