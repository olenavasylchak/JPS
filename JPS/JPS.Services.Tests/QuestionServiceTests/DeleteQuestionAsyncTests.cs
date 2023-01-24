using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class DeleteQuestionAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationTestDeleteQuestionAsync_GivenValidInput_DatabaseShouldNotContainQuestion()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);

			var questionId = 1;

			var hasDatabaseQuestion = await DbContext.Questions.AnyAsync(question => question.Id == questionId);
			Assert.IsTrue(hasDatabaseQuestion);

			await QuestionService.DeleteQuestionAsync(questionId);

			hasDatabaseQuestion = await DbContext.Questions.AnyAsync(question => question.Id == questionId);
			Assert.IsFalse(hasDatabaseQuestion);
		}

		[TestMethod]
		public async Task TestDeleteQuestionAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.DeleteQuestionAsync(questionEntity.Id);
			});
		}

		[TestMethod]
		public async Task TestDeleteQuestionAsync_QuestionDoesntExist_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.DeleteQuestionAsync(1);
			});
		}

		[TestMethod]
		public async Task TestDeleteQuestionAsync_PrototypeIdTest_ShouldBePassed()
		{
			var question1 = GetQuestionEntity();
			question1.Id = 1;
			question1.PrototypeQuestionId = 1;
			await AddItems(DbContext, question1);

			var question2 = GetQuestionEntity();
			question2.Id = 2;
			question2.PrototypeQuestionId = 1;
			await AddItems(DbContext, question2);

			var question3 = GetQuestionEntity();
			question3.Id = 3;
			question3.PrototypeQuestionId = 1;
			await AddItems(DbContext, question3);

			await QuestionService.DeleteQuestionAsync(1);
			var question = DbContext.Questions.Find(3);

			var expectedPrototypeId = 2;

			Assert.AreEqual(question.PrototypeQuestionId, expectedPrototypeId);

		}

		private QuestionEntity GetQuestionEntity()
		{
			var questionEntity = new QuestionEntity
			{
				Text = "first question",
				CanHaveOtherOption = false,
				IsRequired = false,
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "image url",
				VideoUrl = "video url"
			};

			return questionEntity;
		}
	}
}
