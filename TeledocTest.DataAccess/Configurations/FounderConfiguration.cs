using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess.Configurations
{
    public class FounderConfiguration : IEntityTypeConfiguration<FounderEntity>
    {
        public void Configure(EntityTypeBuilder<FounderEntity> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.FirstName)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(f => f.LastName)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(f => f.INN)
                   .IsRequired()
                   .HasMaxLength(12);

            builder.Property(f => f.CreatedAt)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(f => f.UpdatedAt)
                   .IsRequired()
                   .ValueGeneratedOnAddOrUpdate();
        }
    }
}
