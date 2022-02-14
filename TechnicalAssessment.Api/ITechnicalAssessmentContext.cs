using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api
{
    public interface ITechnicalAssessmentContext : IDisposable
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancelationToken);
    }
}
