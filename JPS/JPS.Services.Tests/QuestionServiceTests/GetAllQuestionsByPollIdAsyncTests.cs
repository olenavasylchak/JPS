using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class GetAllQuestionsByPollIdAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationTestGetAllQuestionsByPollIdAsync_GivenValidInput_ShouldBePassed()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var actualQuestionDTOs = await QuestionService.GetAllQuestionsByPollIdAsync(1);
			var expectedQuestionDTOs = GetExpectedQuestionDTOs();

			var questionComparer = new QuestionDTOComparer();
			var result = actualQuestionDTOs.Zip(expectedQuestionDTOs,
				(first, second) => questionComparer.Compare(first, second))
				.FirstOrDefault(res => res != 0);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public async Task TestGetAllQuestionsByPollIdAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionSectionEntity = new QuestionSectionEntity { Id = 1, Title = "title" };
			await AddItems(DbContext, questionSectionEntity);
			await AddItems(DbContext, GetQuestionEntityModel(id: 1));

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.GetAllQuestionsByPollIdAsync(1);
			});
		}

		private IEnumerable<QuestionDTO> GetExpectedQuestionDTOs()
		{
			var questionDTOs = new List<QuestionDTO>
			{
				new QuestionDTO
				{
					Id = 1,
					QuestionSectionId = 1,
					Text = "first question",
					CanHaveOtherOption = false,
					IsRequired = false,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				},
				new QuestionDTO
				{
					Id = 2,
					QuestionSectionId = 2,
					Text = "second question",
					CanHaveOtherOption = false,
					IsRequired = true,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				}
			};

			return questionDTOs;
		}

		private PollEntity GetPollEntity()
		{
			var pollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "first question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					},
					new QuestionSectionEntity
					{
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "second question",
								CanHaveOtherOption = false,
								IsRequired = true,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};

			return pollEntity;
		}

		public static QuestionEntity GetQuestionEntityModel(
			int id = 1,
			int questionSectionId = 1,
			string text = "text",
			string comment = "commet",
			int order = 1,
			bool canHaveOtherOptions = false,
			bool isRequired = false,
			int? prototypeQuestionId = 1,
			int questionTypeId = 1,
			string ImageUrl = null,
			string VideoUrl = null
			)
		{
			var newQuestionSection = new QuestionEntity
			{
				Id = id,
				QuestionSectionId = questionSectionId,
				Text = text,
				Comment = comment,
				Order = order,
				CanHaveOtherOption = canHaveOtherOptions,
				IsRequired = isRequired,
				PrototypeQuestionId = prototypeQuestionId,
				QuestionTypeId = questionTypeId,
				ImageUrl = ImageUrl,
				VideoUrl = VideoUrl,
			};
			return newQuestionSection;
		}
	}
}
