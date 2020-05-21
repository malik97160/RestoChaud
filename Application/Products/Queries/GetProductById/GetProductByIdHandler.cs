using Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestoChaud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductVm>
    {
        private readonly IRestoChaudContext _context;
        public GetProductByIdHandler(IRestoChaudContext context)
        {
            _context = context;
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var produt = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken).ConfigureAwait(false);
            if (produt == null)
                throw new NotFoundException(nameof(Product), request.ProductId);
            return new ProductVm();
        }
    }
}
