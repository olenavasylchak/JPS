using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
	public class QuestionSectionConfiguration : IEntityTypeConfiguration<QuestionSectionEntity>
	{
		public void Configure(EntityTypeBuilder<QuestionSectionEntity> builder)
		{
			builder.ToTable("QuestionSections").HasKey(q => q.Id);
			builder.Property(q => q.Id).ValueGeneratedOnAdd();
			builder.Property(q => q.Title).HasMaxLength(100);
			builder.Property(q => q.PollId).IsRequired();
			builder.Property(q => q.Order).IsRequired();
			builder.HasOne(p => p.Poll)
				.WithMany(qs => qs.QuestionSections)
				.HasForeignKey(p => p.PollId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
