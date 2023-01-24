using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.AnswerComparers;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;

namespace JPS.Services.Tests.AnswerServiceTests
{
	[TestClass]
	public class AnswerServiceGetAnswersByQuestionIdAsyncTests : AnswerServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			AnswerService = new AnswerService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationTest_GetAnswersByQuestionId()
		{
			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "",
				QuestionSectionId = 1,
				IsRequired = false,
				CanHaveOtherOption = true,
				Comment = "",
				Order = 1,
				PrototypeQuestionId = 1,
				QuestionTypeId = 4
			});

			await AddItems(DbContext, new AnswerEntity
			{
				Id = 1,
				UserId = "userId",
				QuestionId = 1,
				TextAnswer = new TextAnswerEntity
				{
					Text = "text"
				},
				OptionAnswers = new List<OptionAnswerEntity>
				{
					new OptionAnswerEntity
					{
						Id = 2,
						OptionId = 1,
						AnswerId = 1,
						Option = new OptionEntity
						{
							Id = 1,
							QuestionId = 1,
							Order = 1,
							Text = "option1"
						}
					}
				}
			});

			var actualAnswerDTOs = await AnswerService.GetAnswersByQuestionIdAsync(1);

			var expectedAnswerDTOs = GetExpectedAnswerDTOs();

			var result = actualAnswerDTOs
				.Zip(expectedAnswerDTOs, (first, second) => new AnswerDTOComparer()
				.Compare(first, second))
				.Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task GetAnswersByQuestionId_GivenNotExistingQuestionId_ShouldThrowNotFoundException()
		{
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
				await AnswerService.GetAnswersByQuestionIdAsync(6);
			});
		}

		private IEnumerable<AnswerDTO> GetExpectedAnswerDTOs()
		{
			var expectedAnswerDTOs = new List<AnswerDTO>
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
					OptionAnswers=new List<OptionAnswerDTO>
					{
						new OptionAnswerDTO
						{
							Id = 2,
							OptionId = 1,
							AnswerId = 1,
							Option = new OptionDTO
							{
								Id = 1,
								QuestionId = 1,
								Order = 1,
								Text = "option1"
							},
						}
					}
				}
			};

			return expectedAnswerDTOs;
		}
	}
}