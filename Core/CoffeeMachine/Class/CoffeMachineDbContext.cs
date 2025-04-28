using Microsoft.EntityFrameworkCore;

namespace SmartCoffeeMachine.Core.CoffeeMachine.Class
{
    /// <summary>
    /// DbContext is used for CRUD db rows
    /// Use SaveChanges or SaveChangesAsync to persist data.
    /// </summary>
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options) : base(options)
        {
        }

        public DbSet<CoffeeMachineLogs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoffeeMachineLogs>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TimeStamp)
                      .IsRequired();

                entity.Property(e => e.Action)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(e => e.Status)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.ParametersJson)
                      .HasColumnType("nvarchar(max)");

                entity.Property(e => e.ResultsJson)
                      .HasColumnType("nvarchar(max)");

                entity.Property(e => e.ErrorMessage)
                      .HasColumnType("nvarchar(max)");
            });
        }
    }
}
