using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
	public class OptionConfiguration : IEntityTypeConfiguration<OptionEntity>
	{
		public void Configure(EntityTypeBuilder<OptionEntity> builder)
		{
			builder.ToTable("Options").HasKey(o => o.Id);
			builder.Property(o => o.Id).ValueGeneratedOnAdd();
			builder.Property(o => o.QuestionId).IsRequired();
			builder.Property(o => o.Text).HasMaxLength(100);
			builder.Property(o => o.Order).IsRequired();
			builder.HasOne(o => o.Question)
				.WithMany(q => q.Options)
				.HasForeignKey(o => o.QuestionId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}