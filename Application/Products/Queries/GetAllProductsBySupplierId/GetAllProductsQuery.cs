using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
        public GetAllProductsQuery(int supplierId)
        {
            SupplierId = supplierId;
        }
        public int SupplierId { get;}
    }
}
