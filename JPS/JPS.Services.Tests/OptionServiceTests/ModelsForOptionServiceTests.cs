using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.OptionDTOs;

namespace JPS.Services.Tests.OptionServiceTests
{
	public static class ModelsForOptionServiceTests
	{
		public static QuestionEntity GetQuestionEntityModel(
			int id = 1,
			string text = "test text",
			bool isRequired = true,
			int questionSectionId = 1,
			bool canHaveOtherOption = false,
			string comment = "comment",
			string imageUrl = "img",
			string videoUrl = "vid",
			int order = 1,
			int questionTypeId = 4)
		{
			var questionEntity = new QuestionEntity
			{
				Id = id,
				Text = text,
				QuestionSectionId = questionSectionId,
				IsRequired = isRequired,
				CanHaveOtherOption = canHaveOtherOption,
				Comment = comment,
				Order = order,
				QuestionTypeId = questionTypeId,
				ImageUrl = imageUrl,
				VideoUrl = videoUrl,
			};
			return questionEntity;
		}

		public static OptionEntity GetOptionEntityModel(
			int id = 1,
			int questionId = 1,
			string text = "test text",
			string imageUrl = "",
			int order = 1,
			decimal? value = null)
		{
			var optionEntity = new OptionEntity()
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order,
				Value = value
			};
			return optionEntity;
		}

		public static OptionDTO GetOptionDTOModel(
			int id = 1,
			int questionId = 1,
			string text = "test text",
			string imageUrl = "",
			int order = 1,
			decimal? value = null)
		{
			var optionDTO = new OptionDTO()
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order,
				Value = value
			};
			return optionDTO;
		}
	}
}
