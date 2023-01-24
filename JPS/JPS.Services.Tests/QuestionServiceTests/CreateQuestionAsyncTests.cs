using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class CreateQuestionAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationCreateQuestionAsync_GivenValidInput_ShouldBePassed()
		{
			var questionSection = new QuestionSectionEntity
			{
				Description = "nothing",
				Order = 1
			};
			await AddItems(DbContext, questionSection);

			var createQuestionDTO = GetCreateQuestionDTO();

			var expectedQuestionDTO = GetExpectedQuestionDTO();
			var actualQuestionDTO = await QuestionService.CreateQuestionAsync(createQuestionDTO);

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
				);
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenTextTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.Text;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenParagraphTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.Paragraph;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenDropDownTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.Dropdown;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenLinearScaleTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.LinearScale;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenFileTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.FileUpload;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenMultipleChoiceGridTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.MultipleChoiceGrid;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenCheckboxGridTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.CheckboxGrid;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenDateTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.Date;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenTimeTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.Time;


			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenChoiceTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.MultipleChoice;


			var question = await QuestionService.CreateQuestionAsync(createQuestionDTO);

			Assert.IsNotNull(question);
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_GivenCheckBoxTypeForOtherOption_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.CheckBoxes;


			var question = await QuestionService.CreateQuestionAsync(createQuestionDTO);

			Assert.IsNotNull(question);
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_SectionDoesntExist_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			section.Id = 5;
			await AddItems(DbContext, section);

			var createQuestionDTO = GetCreateQuestionDTO();
			createQuestionDTO.CanHaveOtherOption = true;
			createQuestionDTO.QuestionTypeId = (int)QuestionTypes.MultipleChoice;


			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionAsync_NotUniqueOrder_ShouldThrowException()
		{
			var section = GetQuestionSectionEntityModel();
			await AddItems(DbContext, section);
			await AddItems(DbContext, GetQuestionEntityModel(id: 2, order: 1));

			var createQuestionDTO = GetCreateQuestionDTO();

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.CreateQuestionAsync(createQuestionDTO);
			});
		}

		private CreateQuestionDTO GetCreateQuestionDTO()
		{
			var createQuestionDTO = new CreateQuestionDTO
			{
				Text = "test text",
				QuestionSectionId = 1,
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "test comment",
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "test url",
				VideoUrl = "test url"
			};

			return createQuestionDTO;
		}

		private QuestionDTO GetExpectedQuestionDTO()
		{
			var questionDTO = new QuestionDTO()
			{
				Id = 1,
				Text = "test text",
				QuestionSectionId = 1,
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "test comment",
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "test url",
				VideoUrl = "test url"
			};

			return questionDTO;
		}
		public static QuestionSectionEntity GetQuestionSectionEntityModel(
			int id = 1,
			int pollId = 1,
			string title = "title",
			string description = "description",
			int order = 1
			)
		{
			var newQuestionSection = new QuestionSectionEntity
			{
				Id = id,
				PollId = pollId,
				Title = title,
				Description = description,
				Order = order,

			};
			return newQuestionSection;
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
