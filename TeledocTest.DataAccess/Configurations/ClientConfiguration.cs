using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.INN)
                   .IsRequired()
                   .HasMaxLength(12);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(c => c.Type)
                   .IsRequired();

            builder.HasMany(c => c.Founders)
                   .WithOne()
                   .HasForeignKey("client_id")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.UpdatedAt)
                   .IsRequired()
                   .ValueGeneratedOnAddOrUpdate();
        }
    }
}
