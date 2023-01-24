using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPS.Services.Tests.AnswerServiceTests
{
	[TestClass]
	public class AnswerServiceCreatePollAnswersAsyncTests : AnswerServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			AnswerService = new AnswerService(DbContext, Mapper);
			UserClaimsService = new UserClaimsAccessorService(HttpContextAccessorMock.Object);

			var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "fakeUserId")
			}));
			var context = new DefaultHttpContext()
			{
				User = fakeUser
			};
			context.Request.Headers["Tenant-ID"] = "fakeTenantId";
			HttpContextAccessorMock.Setup(_ => _.HttpContext).Returns(context);
		}

		[TestMethod]
		public async Task IntegrationTest_CreatePollAnswers()
		{
			await AddItems(DbContext, new PollEntity
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = null,
				CreatedAt = new DateTime(2020, 05, 23)
			});

			await AddItems(DbContext, new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "title",
				Description = "description",
				Order = 1
			});

			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "",
				QuestionSectionId = 1,
				IsRequired = false,
				CanHaveOtherOption = false,
				Comment = "",
				Order = 1,
				PrototypeQuestionId = 1,
				QuestionTypeId = 1,
				ImageUrl = "",
				VideoUrl = "",
				PrototypeQuestion = null,
				QuestionClones = null,
				QuestionSection = null,
				QuestionType = null,
				Options = null,
				OptionRows = null,
				Answers = null
			});

			var answer = GetCreatePollAnswerDTO(1);

			await AnswerService.CreatePollAnswersAsync(answer, UserClaimsService);

			var hasDbContextAnswer = await HasDbUserPollAnswer(DbContext, 1, UserClaimsService.UserId);

			Assert.IsTrue(hasDbContextAnswer);
		}

		[TestMethod]
		public async Task TestCreatePollAnswers_GivenNotExistingPollId_ShouldThrowNotFoundException()
		{
			await AddItems(DbContext, new PollEntity
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = null,
				CreatedAt = new DateTime(2020, 05, 23)
			});

			await AddItems(DbContext, new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "title",
				Description = "description",
				Order = 1
			});

			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "",
				QuestionSectionId = 1,
				IsRequired = false,
				CanHaveOtherOption = false,
				Comment = "",
				Order = 1,
				PrototypeQuestionId = 1,
				QuestionTypeId = 1,
				ImageUrl = "",
				VideoUrl = "",
				PrototypeQuestion = null,
				QuestionClones = null,
				QuestionSection = null,
				QuestionType = null,
				Options = null,
				OptionRows = null,
				Answers = null
			});

			var answer = GetCreatePollAnswerDTO(2);

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnswerService.CreatePollAnswersAsync(answer, UserClaimsService);
			});
		}

		[TestMethod]
		public async Task TestCreatePollAnswers_GivenAnswerSecondTime_ShouldThrowNotAllowedException()
		{
			await AddItems(DbContext, new PollEntity
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = null,
				CreatedAt = new DateTime(2020, 05, 23)
			});

			await AddItems(DbContext, new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "title",
				Description = "description",
				Order = 1
			});

			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "",
				QuestionSectionId = 1,
				IsRequired = false,
				CanHaveOtherOption = false,
				Comment = "",
				Order = 1,
				PrototypeQuestionId = 1,
				QuestionTypeId = 1,
				ImageUrl = "",
				VideoUrl = "",
				PrototypeQuestion = null,
				QuestionClones = null,
				QuestionSection = null,
				QuestionType = null,
				Options = null,
				OptionRows = null,
				Answers = null
			});

			await AddItems(DbContext, new AnswerEntity
			{
				Id = 1,
				UserId = UserClaimsService.UserId,
				QuestionId = 1,
				TextAnswer = new TextAnswerEntity()
				{
					Text = "text2"
				}
			});

			var answer = GetCreatePollAnswerDTO(1);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await AnswerService.CreatePollAnswersAsync(answer, UserClaimsService);
			});
		}

		[TestMethod]
		public async Task TestCreatePollAnswers_GivenAnswerAfterPollEnded_ShouldThrowNotAllowedException()
		{
			await AddItems(DbContext, new PollEntity
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = new DateTime(2020, 05, 24),
				CreatedAt = new DateTime(2020, 05, 23)
			});

			await AddItems(DbContext, new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "title",
				Description = "description",
				Order = 1
			});

			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "",
				QuestionSectionId = 1,
				IsRequired = false,
				CanHaveOtherOption = false,
				Comment = "",
				Order = 1,
				PrototypeQuestionId = 1,
				QuestionTypeId = 1,
				ImageUrl = "",
				VideoUrl = "",
				PrototypeQuestion = null,
				QuestionClones = null,
				QuestionSection = null,
				QuestionType = null,
				Options = null,
				OptionRows = null,
				Answers = null
			});

			var answer = GetCreatePollAnswerDTO(1);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await AnswerService.CreatePollAnswersAsync(answer, UserClaimsService);
			});
		}

		private CreatePollAnswersDTO GetCreatePollAnswerDTO(int pollId)
		{
			var createPollAnswerDTO = new CreatePollAnswersDTO()
			{
				PollId = pollId,
				Answers = new List<PollAnswersDTO>()
				{
					new PollAnswersDTO()
					{
						UserId = UserClaimsService.UserId,
						QuestionId = 1,
						TextAnswer = new CreateTextAnswerDTO()
						{
							Text = "some another text"
						}
					}
				}
			};

			return createPollAnswerDTO;
		}

		private async Task<bool> HasDbUserPollAnswer(JPSContext context, int pollId, string userId)
		{
			return await context.Answers.AnyAsync(
				answer => answer.UserId == userId
						  && answer.Question.QuestionSection.PollId == pollId
			);
		}
	}
}
