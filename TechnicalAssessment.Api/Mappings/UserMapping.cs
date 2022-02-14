using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(x => x.Id)
                .HasName("PK_Users");

            builder
                .Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasIndex(x => x.UserName)
                .IsUnique(true);

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
