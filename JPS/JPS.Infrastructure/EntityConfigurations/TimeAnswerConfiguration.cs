using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class TimeAnswerConfiguration : IEntityTypeConfiguration<TimeAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<TimeAnswerEntity> builder)
        {
            builder.ToTable("TimeAnswers").HasKey(t => t.AnswerId);
            builder.Property(t => t.Time).IsRequired();
        }
    }
}
