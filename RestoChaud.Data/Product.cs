using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoChaud.Data
{
    public class Product
    {
        public Product()
        {
            ProductCompositionsComponent = new HashSet<ProductComposition>();
            ProductCompositionsProduct = new HashSet<ProductComposition>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        [Column(TypeName = "decimal(8, 3)")]
        public decimal? QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        [InverseProperty(nameof(ProductComposition.Component))]
        public virtual ICollection<ProductComposition> ProductCompositionsComponent { get; set; }
        [InverseProperty(nameof(ProductComposition.Product))]
        public virtual ICollection<ProductComposition> ProductCompositionsProduct { get; set; }
    }
}
