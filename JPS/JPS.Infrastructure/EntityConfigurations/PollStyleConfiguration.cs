using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
	public class PollStyleConfiguration : IEntityTypeConfiguration<PollStyleEntity>
	{
		public void Configure(EntityTypeBuilder<PollStyleEntity> builder)
		{
			builder.ToTable("PollStyles").HasKey(ps=>ps.PollId);
			builder.Property(ps => ps.Font).IsRequired();
			builder.Property(ps => ps.ThemeColor).IsRequired()
				.HasMaxLength(7)
				.IsFixedLength();
			builder.Property(ps => ps.Opacity).HasColumnType("decimal")
				.IsRequired();
			builder.Property(ps => ps.ImageXCoordinate).HasColumnType("float");
			builder.Property(ps => ps.ImageYCoordinate).HasColumnType("float");
		}
	}
}
