using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories").HasKey(с => с.Id);
            builder.Property(с => с.Id).ValueGeneratedOnAdd();
            builder.Property(с => с.Title).HasMaxLength(100).IsRequired();
            builder.Property(с => с.CreatedAt).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasOne(c => c.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(p => p.ParentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
