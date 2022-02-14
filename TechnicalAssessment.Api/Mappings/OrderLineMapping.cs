using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Mappings
{
    public class OrderLineMapping : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder
                .ToTable("OrderLines")
                .HasKey(x => x.Id)
                .HasName("PK_OrderLines");

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderLines)
                .HasForeignKey(x => x.OrderId);

            builder
               .Property(x => x.ItemCode)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}
