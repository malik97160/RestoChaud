using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}
