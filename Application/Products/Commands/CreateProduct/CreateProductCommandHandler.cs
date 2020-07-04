using MediatR;
using RestoChaud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        public readonly IRestoChaudContext _context;
        public CreateProductCommandHandler(IRestoChaudContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                UnitPrice = request.UnitPrice
            };

            _context.Products.Add(entity);

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
