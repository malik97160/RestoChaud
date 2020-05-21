using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetAllProductsBySupplierId
{
    public class GetAllProductsBySupplierIdValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductsBySupplierIdValidator()
        {
            RuleFor(v => v.SupplierId).GreaterThan(0);
        }
    }
}
