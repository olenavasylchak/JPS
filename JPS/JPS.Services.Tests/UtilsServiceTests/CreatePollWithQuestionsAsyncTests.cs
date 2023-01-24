using JPS.Services.Comparers.PollComparers;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;

namespace JPS.Services.Tests.UtilsServiceTests
{
	[TestClass]
	public class UtilsServiceCreatePollWithQuestionAsyncMethodUnitTests : UtilsServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			UtilsService = new UtilsService(DbContext, Mapper, AzureBlobStorageOptions);
		}

		[TestMethod]
		public async Task IntegrationTestCreatePollWithQuestionsAsync_GivenValidInput_ShouldBePassed()
		{
			var categoryEntity = new CategoryEntity
			{
				Title = "test",
			};
			await AddItems(DbContext, categoryEntity);

			var createPollWithQuestionSectionsDTO = GetCreatePollWithQuestionSectionsDTO();
			var actualPollDTO = await UtilsService.CreatePollWithQuestionsAsync(createPollWithQuestionSectionsDTO);

			var expectedPollDTO = GetExpectedPollDTO();
			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPollDTO, actualPollDTO));

			var pollEntity = await DbContext.Polls.FindAsync(1);
			Assert.IsNotNull(pollEntity);
		}

		private PollDTO GetExpectedPollDTO()
		{
			var expectedPollDTO = new PollDTO
			{
				Id = 1,
				CategoryId = 1,
				Title = "test title",
				Description = "description",
				QuestionSections = new List<QuestionSectionDTO>
				{
					new QuestionSectionDTO
					{
						Id = 1,
						PollId = 1,
						Title = "test title",
						Description = "description",
						Order = 1,
						Questions = new List<QuestionDTO>
						{
							new QuestionDTO
							{
								Id = 1,
								Text = "test text",
								QuestionSectionId = 1,
								CanHaveOtherOption = false,
								IsRequired = true,
								Comment = "test comment",
								Order = 1,
								QuestionTypeId = 9,
								ImageUrl = "test image url",
								VideoUrl = "test video url",
								Options = new List<QuestionOptionDTO>
								{
									new QuestionOptionDTO
									{
										Id = 1,
										Text = "test text",
										ImageUrl = "test url",
										Order = 1
									}
								},
								OptionRows = new List<OptionRowDTO>
								{
									new OptionRowDTO
									{
										Id = 1,
										QuestionId = 1,
										Text = "test text",
										ImageUrl = "test url",
										Order = 1
									}
								}
							}
						}
					}
				}
			};
			return expectedPollDTO;
		}

		[TestMethod]
		public async Task TestCreatePollMethodCategoryValidation_GivenNotExistingCategoryId_ShouldThrowException()
		{
			var createPollWithQuestionSectionsDTO = GetCreatePollWithQuestionSectionsDTO();

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
				{
					await UtilsService.CreatePollWithQuestionsAsync(createPollWithQuestionSectionsDTO);
				});
		}

		private CreatePollWithQuestionSectionsDTO GetCreatePollWithQuestionSectionsDTO(
			int? categoryId = 1,
			string title = "test title",
			string description = "description",
			DateTimeOffset? finishesAt = null,
			DateTimeOffset? startsAt = null
		)
		{
			var createPollWithQuestionSectionsDTO = new CreatePollWithQuestionSectionsDTO
			{
				CategoryId = categoryId,
				Title = title,
				Description = description,
				FinishesAt = finishesAt,
				StartsAt = startsAt,
				QuestionSections = new List<CreateQuestionSectionWithQuestionsDTO>
				{
					new CreateQuestionSectionWithQuestionsDTO
					{
						Title = "test title",
						Description = "description",
						Order = 1,
						Questions = new List<CreateQuestionsDTO>
						{
							new CreateQuestionsDTO
							{
								Text = "test text",
								CanHaveOtherOption = false,
								IsRequired = true,
								Comment = "test comment",
								Order = 1,
								QuestionTypeId = 9,
								ImageUrl = "test image url",
								VideoUrl = "test video url",
								Options = new List<CreateOptionForQuestionDTO>
								{
									new CreateOptionForQuestionDTO
									{
										Text = "test text",
										Order = 1,
										ImageUrl = "test url"
									}
								},
								OptionRows = new List<CreateOptionRowForQuestionDTO>
								{
									new CreateOptionRowForQuestionDTO
									{
										Text = "test text",
										Order = 1,
										ImageUrl = "test url"
									}
								}
							}
						}
					}
				}
			};
			return createPollWithQuestionSectionsDTO;
		}
	}
}
