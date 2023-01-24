using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class FileAnswerConfiguration : IEntityTypeConfiguration<FileAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<FileAnswerEntity> builder)
        {
            builder.ToTable("FileAnswers").HasKey(f => f.AnswerId);
            builder.Property(f => f.FileUrl).IsRequired();
        }
    }
}