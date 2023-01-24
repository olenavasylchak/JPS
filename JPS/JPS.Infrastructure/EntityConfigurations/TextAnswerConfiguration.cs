using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class TextAnswerConfiguration : IEntityTypeConfiguration<TextAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<TextAnswerEntity> builder)
        {
            builder.ToTable("TextAnswers").HasKey(t => t.AnswerId);
            builder.Property(t => t.Text).HasMaxLength(250).IsRequired();
        }
    }
}
