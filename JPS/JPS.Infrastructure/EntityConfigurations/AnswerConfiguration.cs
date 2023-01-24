using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<AnswerEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder.ToTable("Answers").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId).HasMaxLength(128).IsRequired();
            builder.Property(a => a.QuestionId).IsRequired();
            builder.HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.FileAnswer)
                .WithOne(a => a.Answer)
                .HasForeignKey<FileAnswerEntity>(a => a.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.TextAnswer)
                .WithOne(a => a.Answer)
                .HasForeignKey<TextAnswerEntity>(t => t.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(d => d.DateAnswer)
               .WithOne(a => a.Answer)
               .HasForeignKey<DateAnswerEntity>(d => d.AnswerId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.TimeAnswer)
              .WithOne(a => a.Answer)
              .HasForeignKey<TimeAnswerEntity>(t => t.AnswerId)
              .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.ParagraphAnswer)
             .WithOne(a => a.Answer)
             .HasForeignKey<ParagraphAnswerEntity>(p => p.AnswerId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
