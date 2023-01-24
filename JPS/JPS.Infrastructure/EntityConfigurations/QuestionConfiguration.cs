using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
	public class QuestionConfiguration : IEntityTypeConfiguration<QuestionEntity>
	{
		public void Configure(EntityTypeBuilder<QuestionEntity> builder)
		{
			builder.ToTable("Questions").HasKey(q => q.Id);
			builder.Property(q => q.Id).ValueGeneratedOnAdd();
			builder.Property(q => q.Text).IsRequired();
			builder.Property(q => q.QuestionSectionId).IsRequired();
			builder.Property(q => q.QuestionTypeId).IsRequired();
			builder.Property(q => q.IsRequired).IsRequired();
			builder.Property(q => q.Order).IsRequired();
			builder.Property(q => q.CanHaveOtherOption).HasDefaultValue(false);
			builder.Property(q => q.Comment).HasMaxLength(250);
			builder.HasOne(qs => qs.QuestionSection)
				.WithMany(q => q.Questions)
				.HasForeignKey(qs => qs.QuestionSectionId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(qt => qt.QuestionType)
				.WithMany(q => q.Questions)
				.HasForeignKey(qt => qt.QuestionTypeId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(q => q.PrototypeQuestion)
				.WithMany(q => q.QuestionClones)
				.HasForeignKey(q => q.PrototypeQuestionId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
