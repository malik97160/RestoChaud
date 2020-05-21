using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestoChaud.Data
{
    public interface IRestoChaudContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ProductComposition> ProductCompositions { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Site> Sites { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}