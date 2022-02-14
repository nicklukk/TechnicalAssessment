using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders")
                .HasKey(x => x.Id)
                .HasName("PK_Orders");

            builder
                .Property(x => x.Reference)
                .HasMaxLength(250);

            builder
                .Property(x => x.CustomerName)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);
        }
    }
}
