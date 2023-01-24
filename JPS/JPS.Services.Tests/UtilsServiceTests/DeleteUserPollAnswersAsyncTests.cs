using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Enums;
using JPS.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.UtilsServiceTests
{
	[TestClass]
	public class UtilsServiceDeleteUserPollAnswersAsyncMethodUnitTests : UtilsServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			UtilsService = new UtilsService(DbContext, Mapper, AzureBlobStorageOptions);
		}

		[TestMethod]
		public async Task IntegrationTestDeleteUserPollAnswers_FillDatabaseWithAllAnswerTypes_DatabaseShouldBeEmpty()
		{
			var userId = "userId";
			var pollId = 1;
			var answerEntities = new List<AnswerEntity>
			{
				GetTextAnswerEntity(userId),
				GetParagraphAnswerEntity(userId),
				GetDateAnswerEntity(userId),
				GetTimeAnswerEntity(userId),
				GetFileAnswerEntity(userId),
				GetOptionAnswerEntity(userId)
			};

			var pollEntity = GetPollEntity(answerEntities);
			await AddItems(DbContext, pollEntity);

			await UtilsService.DeleteUserPollAnswersAsync(userId, pollId);

			var hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.Text, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.Paragraph, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.Time, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.Date, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.FileUpload, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, QuestionTypes.MultipleChoice, pollId, userId);
			Assert.IsFalse(hasDbContextSpecificAnswer);

			var hasDbContextAnswer = await HasDbUserPollAnswer(DbContext, pollId, userId);
			Assert.IsFalse(hasDbContextAnswer);
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GetTestAnswerEntityModelData), DynamicDataSourceType.Method)]
		public async Task TestDeletingSpecificUserPollAnswers
		(
			string displayName,
			PollEntity pollEntity,
			string userId,
			int pollId,
			QuestionTypes type
			)
		{
			await AddItems(DbContext, pollEntity);

			var hasDbContextAnswer = await HasDbUserPollAnswer(DbContext, pollId, userId);
			var hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, type, pollId, userId);

			Assert.IsTrue(hasDbContextAnswer);
			Assert.IsTrue(hasDbContextSpecificAnswer);

			await UtilsService.DeleteUserPollAnswersAsync(userId, pollId);

			hasDbContextAnswer = await HasDbUserPollAnswer(DbContext, pollId, userId);
			hasDbContextSpecificAnswer = await HasDbSpecificAnswer(DbContext, type, pollId, userId);

			Assert.IsFalse(hasDbContextAnswer);
			Assert.IsFalse(hasDbContextSpecificAnswer);
		}

		private async Task<bool> HasDbUserPollAnswer(
			JPSContext context,
			int pollId,
			string userId
		)
		{
			return await context.Answers.AnyAsync(
				answer => answer.UserId == userId
						  && answer.Question.QuestionSection.PollId == pollId
			);
		}

		private async Task<bool> HasDbSpecificAnswer(
			JPSContext context,
			QuestionTypes type,
			int pollId,
			string userId
			)
		{
			return type switch
			{
				QuestionTypes.Paragraph => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.ParagraphAnswer != null),
				QuestionTypes.Text => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.TextAnswer != null),
				QuestionTypes.Time => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.TimeAnswer != null),
				QuestionTypes.Date => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.DateAnswer != null),
				QuestionTypes.MultipleChoice => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.OptionAnswers != null),
				QuestionTypes.FileUpload => await context.Answers.AnyAsync(
					answer => answer.UserId == userId
							  && answer.Question.QuestionSection.PollId == pollId
							  && answer.FileAnswer != null),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};

		}

		private static IEnumerable<object[]> GetTestAnswerEntityModelData()
		{
			var userId = "userId";
			var pollId = 1;

			yield return new object[]
			{
				"Test case 1: DeleteUserPollAnswers_GivenTextAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetTextAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.Text
			};

			yield return new object[]
			{
				"Test case 2: DeleteUserPollAnswers_GivenParagraphAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetParagraphAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.Paragraph
			};

			yield return new object[]
			{
				"Test case 3: DeleteUserPollAnswers_GivenTimeAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetTimeAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.Time
			};

			yield return new object[]
			{
				"Test case 4: DeleteUserPollAnswers_GivenDateAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetDateAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.Date
			};

			yield return new object[]
			{
				"Test case 5: DeleteUserPollAnswers_GivenFileAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetFileAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.FileUpload
			};

			yield return new object[]
			{
				"Test case 6: DeleteUserPollAnswers_GivenOptionAnswerEntity_ShouldBePassed",
				GetPollEntity(new List<AnswerEntity>
				{
					GetOptionAnswerEntity(userId)
				}),
				userId,
				pollId,
				QuestionTypes.MultipleChoice
			};
		}

		private static PollEntity GetPollEntity(List<AnswerEntity> answerEntities)
		{
			var pollEntity = new PollEntity
			{
				Title = "test poll",
				Description = "description",
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Title = "Test question section",
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "Test question",
								Answers = answerEntities
							}
						}
					}
				}
			};

			return pollEntity;
		}

		private static AnswerEntity GetTextAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				TextAnswer = new TextAnswerEntity
				{
					Text = "test text"
				}
			};
			return answerEntity;
		}

		private static AnswerEntity GetParagraphAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				ParagraphAnswer = new ParagraphAnswerEntity
				{
					Text = "test text"
				}
			};
			return answerEntity;
		}

		private static AnswerEntity GetDateAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				DateAnswer = new DateAnswerEntity
				{
					Date = DateTimeOffset.Now
				}
			};
			return answerEntity;
		}

		private static AnswerEntity GetTimeAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				TimeAnswer = new TimeAnswerEntity
				{
					Time = new TimeSpan(31, 2, 4, 1)
				}
			};
			return answerEntity;
		}

		private static AnswerEntity GetFileAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				FileAnswer = new FileAnswerEntity()
				{
					FileUrl = "testUrl"
				}
			};
			return answerEntity;
		}

		private static AnswerEntity GetOptionAnswerEntity(string userId)
		{
			var answerEntity = new AnswerEntity
			{
				UserId = userId,
				OptionAnswers = new List<OptionAnswerEntity>
				{
					new OptionAnswerEntity()
				}
			};
			return answerEntity;
		}
	}
}
