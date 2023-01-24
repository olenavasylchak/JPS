using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace JPS.Infrastructure.Context
{
	public class JPSContext : DbContext
	{
		public JPSContext(DbContextOptions<JPSContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new PollConfiguration());
			modelBuilder.ApplyConfiguration(new QuestionTypeConfiguration());
			modelBuilder.ApplyConfiguration(new QuestionConfiguration());
			modelBuilder.ApplyConfiguration(new QuestionSectionConfiguration());
			modelBuilder.ApplyConfiguration(new OptionConfiguration());
			modelBuilder.ApplyConfiguration(new OptionRowConfiguration());
			modelBuilder.ApplyConfiguration(new AnswerConfiguration());
			modelBuilder.ApplyConfiguration(new ParagraphAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new FileAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new OptionAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new TextAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new DateAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new TimeAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new ParagraphAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new PollStyleConfiguration());

			JPSDBInitializer.InitializeDB(modelBuilder);
		}
		public DbSet<OptionEntity> Options { get; set; }
		public DbSet<OptionRowEntity> OptionRows { get; set; }
		public DbSet<PollEntity> Polls { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<DateAnswerEntity> DateAnswers { get; set; }
		public DbSet<TimeAnswerEntity> TimeAnswers { get; set; }
		public DbSet<TextAnswerEntity> TextAnswers { get; set; }
		public DbSet<AnswerEntity> Answers { get; set; }
		public DbSet<QuestionEntity> Questions { get; set; }
		public DbSet<QuestionSectionEntity> QuestionSections { get; set; }
		public DbSet<QuestionTypeEntity> QuestionTypes { get; set; }
		public DbSet<FileAnswerEntity> FileAnswers { get; set; }
		public DbSet<OptionAnswerEntity> OptionAnswers { get; set; }
		public DbSet<ParagraphAnswerEntity> ParagraphAnswers { get; set; }
		public DbSet<PollStyleEntity> PollStyles { get; set; }
	}
}
