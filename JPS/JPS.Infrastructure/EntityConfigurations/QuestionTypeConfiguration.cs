using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionTypeEntity> builder)
        {
            builder.ToTable("QuestionTypes").HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();
            builder.Property(q => q.Title).HasMaxLength(100);
        }
    }
}
