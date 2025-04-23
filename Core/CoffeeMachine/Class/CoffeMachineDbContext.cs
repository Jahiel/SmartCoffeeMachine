using Microsoft.EntityFrameworkCore;

namespace SmartCoffeeMachine.Core.CoffeeMachine.Class
{
    /// <summary>
    /// DbContext is used for CRUD db rows
    /// Use SaveChange or SaveChangesAsync in order to generate SQL request²
    /// </summary>
    /// <param name="options"></param>
    public class CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options) : DbContext(options)
    {
        public DbSet<CoffeeMachineLogs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeMachineLogs>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TimeStamp).IsRequired();
                entity.Property(e => e.Action).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.ErrorMessage);
            });
        }
    }
}
