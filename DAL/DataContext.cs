using Microsoft.EntityFrameworkCore;
using UserMgtAPI.context.models;

namespace UserMgtAPI.context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        // Define your entity DbSet properties here
        // public DbSet



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditTrail>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Deleted = false;
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = 0;
                }
                else
                {
                    entry.Entity.DateUpdated = DateTime.Now;
                    entry.Entity.UpdatedBy = 0;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}