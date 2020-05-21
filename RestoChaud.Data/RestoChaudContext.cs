using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestoChaud.Data
{
    public partial class RestoChaudContext : DbContext, IRestoChaudContext
    {
        public RestoChaudContext()
        {
        }

        public RestoChaudContext(DbContextOptions<RestoChaudContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server=(LocalDb)\\MSSqlLocalDb;Database=RestoChaud;Trusted_Connection=True;");

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ProductComposition> ProductCompositions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).IsFixedLength();
            });

            modelBuilder.Entity<ProductComposition>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ComponentId })
                    .HasName("PK_ProductComposition");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ProductCompositionsComponent)
                    .HasForeignKey(d => d.ComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComposition_ComponentId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCompositionsProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComposition_ProductId");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.SiteId).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_site_Company");

                entity.HasOne(d => d.HeadOffice)
                    .WithMany(p => p.Subsidiaries)
                    .HasForeignKey(d => d.ReferentId)
                    .HasConstraintName("FK_Site_Referent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
