using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api
{
    public class TechnicalAssessmentContext : DbContext, ITechnicalAssessmentContext
    {
        public TechnicalAssessmentContext(DbContextOptions<TechnicalAssessmentContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
