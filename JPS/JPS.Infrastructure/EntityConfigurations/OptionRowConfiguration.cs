using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
	public class OptionRowConfiguration : IEntityTypeConfiguration<OptionRowEntity>
	{
		public void Configure(EntityTypeBuilder<OptionRowEntity> builder)
		{
			builder.ToTable("OptionRows").HasKey(o => o.Id);
			builder.Property(o => o.Id).ValueGeneratedOnAdd();
			builder.Property(o => o.QuestionId).IsRequired();
			builder.Property(o => o.Text).HasMaxLength(100);
			builder.Property(o => o.Order).IsRequired();
			builder.HasOne(or => or.Question)
				.WithMany(q => q.OptionRows)
				.HasForeignKey(or => or.QuestionId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
