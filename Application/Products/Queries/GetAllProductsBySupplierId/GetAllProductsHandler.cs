using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestoChaud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IRestoChaudContext _context;

        public GetAllProductsHandler(IRestoChaudContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsDb = await _context.Products.Where(p => p.SupplierId == null || p.SupplierId == request.SupplierId).ToListAsync(cancellationToken).ConfigureAwait(false); 
            return productsDb.Select(p => new ProductDto(p.ProductId, p.ProductName, "")).ToList();
        }
    }
}
