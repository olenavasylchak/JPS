using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPS.Infrastructure.EntityConfigurations
{
    public class PollConfiguration : IEntityTypeConfiguration<PollEntity>
    {
        public void Configure(EntityTypeBuilder<PollEntity> builder)
        {
            builder.ToTable("Polls").HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.IsAnonymous).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Polls)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PollStyle)
	            .WithOne(ps => ps.Poll)
	            .HasForeignKey<PollStyleEntity>(ps => ps.PollId)
	            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
