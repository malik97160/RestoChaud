using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(int productId, string productName, int categoryId, decimal quantityPerUnit, decimal? unitPrice, decimal? unitsInStock, int supplierId)
            : base(productName, categoryId, quantityPerUnit, unitPrice, unitsInStock, supplierId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}
