using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.PollComparers;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.AnswerServiceTests
{
	[TestClass]
	public class AnswerServiceGetUserAnswersForPollAsyncTests : AnswerServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			AnswerService = new AnswerService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationTest_GetUserAnswersForPoll()
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
				QuestionTypeId = 1,
				ImageUrl = "",
				VideoUrl = ""
			});

			await AddItems(DbContext, new AnswerEntity
			{
				UserId = "userId",
				QuestionId = 1,
				TextAnswer = new TextAnswerEntity
				{
					Text = "text"
				}
			});

			var actualPollDTO = await AnswerService.GetUserAnswersForPollAsync(1, "userId");

			var expectedPollDTO = GetExpectedPollDTO();

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPollDTO, actualPollDTO));
		}

		[TestMethod]
		public async Task TestGetUserAnswersForPoll_GivenNotExistingPollId_ShouldThrowException()
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
				UserId = "userId",
				QuestionId = 1,
				TextAnswer = new TextAnswerEntity
				{
					Text = "text"
				}
			});

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnswerService.GetUserAnswersForPollAsync(6, "userId");
			});
		}

		[TestMethod]
		public async Task TestGetUserAnswersForPoll_TryToGetAnonymous_ShouldThrowNotAllowedException()
		{
			await AddItems(DbContext, new PollEntity
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = true,
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
				UserId = "userId",
				QuestionId = 1,
				TextAnswer = new TextAnswerEntity
				{
					Text = "text"
				}
			});

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await AnswerService.GetUserAnswersForPollAsync(1, "userId");
			});
		}

		[TestMethod]
		public async Task TestGetUserAnswersForPoll_TryToGetAnswerOfUserWhoDidntAnswer_ShouldThrowArgumentException()
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
				UserId = "userId",
				QuestionId = 1,
				TextAnswer = null
			});

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await AnswerService.GetUserAnswersForPollAsync(1, "id of user who didn't answer");
			});
		}
		private PollDTO GetExpectedPollDTO()
		{
			var expectedAnswerDTOs = new PollDTO
			{
				Id = 1,
				CategoryId = null,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = null,
				CreatedAt = new DateTime(2020, 05, 23),
				QuestionSections = new List<QuestionSectionDTO>
				{
					new QuestionSectionDTO
					{
						Id = 1,
						PollId = 1,
						Title = "title",
						Description = "description",
						Order = 1,
						Questions = new List<QuestionDTO>
						{
							new QuestionDTO
							{
								Id = 1,
								Text = "",
								QuestionSectionId = 1,
								IsRequired = false,
								CanHaveOtherOption = false,
								Comment = "",
								Order = 1,
								QuestionTypeId = 1,
								ImageUrl = "",
								VideoUrl = "",
								Answers = new List<AnswerDTO>
								{
									new AnswerDTO
									{
										Id = 1,
										UserId = "userId",
										QuestionId = 1,
										TextAnswer = new TextAnswerDTO
											 {
												Text = "text"
											 },
										OptionAnswers = new List<OptionAnswerDTO>
										{ 
										}
									}
								},
								Options = new List<QuestionOptionDTO>
								{
								}
							}
						}
					}
				}
			};

			return expectedAnswerDTOs;
		}
	}
}
