using Microsoft.EntityFrameworkCore;
using System;
using TechnicalAssessment.Core.Models;

namespace TechnicalAssessment.Core
{
    public interface ITechnicalAssessmentContext : IDisposable
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
