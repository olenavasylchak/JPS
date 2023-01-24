using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class ParagraphAnswerConfiguration : IEntityTypeConfiguration<ParagraphAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<ParagraphAnswerEntity> builder)
        {
            builder.ToTable("ParagraphAnswers").HasKey(p => p.AnswerId);
            builder.Property(p => p.Text).IsRequired();
        }
    }
}
