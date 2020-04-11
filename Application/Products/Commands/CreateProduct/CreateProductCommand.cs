using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(string productName, int categoryId, decimal quantityPerUnit, decimal? unitPrice, decimal? unitsInStock) 
            : base(productName, categoryId, quantityPerUnit, unitPrice, unitsInStock)
        {
        }
    }
}
