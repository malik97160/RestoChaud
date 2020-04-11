using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
