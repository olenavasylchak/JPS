using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class DateAnswerConfiguration : IEntityTypeConfiguration<DateAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<DateAnswerEntity> builder)
        {
            builder.ToTable("DateAnswers").HasKey(d => d.AnswerId);
            builder.Property(d => d.Date).IsRequired();
        }
    }
}
