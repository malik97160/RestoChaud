using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<int>
    {
        public ProductCommand(string productName, int categoryId, decimal quantityPerUnit, decimal? unitPrice, decimal? unitsInStock, int supplierId)
        {
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            CategoryId = categoryId;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            SupplierId = supplierId;
        }

        public string ProductName { get; }
        public int CategoryId { get; }
        public decimal QuantityPerUnit { get; }
        public decimal? UnitPrice { get; }
        public decimal? UnitsInStock { get; }
        public int SupplierId { get; }
        public List<int> CompositionProductIds { get; }
    }
}
