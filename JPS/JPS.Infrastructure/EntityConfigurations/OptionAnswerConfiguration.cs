using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class OptionAnswerConfiguration : IEntityTypeConfiguration<OptionAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<OptionAnswerEntity> builder)
        {
            builder.ToTable("OptionAnswers").HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.OptionId).IsRequired();
            builder.HasOne(o => o.Option)
                .WithMany(o => o.OptionAnswers)
                .HasForeignKey(o => o.OptionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.OptionRow)
                .WithMany(o => o.OptionAnswers)
                .HasForeignKey(o => o.OptionRowId)
                .OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(o => o.Answer)
                 .WithMany(a => a.OptionAnswers)
                 .HasForeignKey(o => o.AnswerId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}