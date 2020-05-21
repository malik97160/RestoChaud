using Application.Common.Exceptions;
using MediatR;
using RestoChaud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRestoChaudContext _context;
        public DeleteProductCommandHandler(IRestoChaudContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId).ConfigureAwait(false);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var isOtherProductComponent = _context.ProductCompositions.Any(od => od.ComponentId == entity.ProductId);
            if (isOtherProductComponent)
            {
                // TODO: Add functional test for this behaviour.
                throw new DeleteFailureException(nameof(Product), request.ProductId, "There are existing products associated with this product.");
            }

            _context.Products.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
