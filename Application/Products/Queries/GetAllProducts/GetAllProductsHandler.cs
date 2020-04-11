using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {

        public Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            Func<List<ProductDto>> resultAction = () =>
            {
                 return new List<ProductDto>()
            {
                new ProductDto(1, "Colombo de cabrit"),
                new ProductDto(2, "Quiche lorraine")
            };
            };
            return Task<List<ProductDto>>.Factory.StartNew(resultAction); 
        }
    }
}
