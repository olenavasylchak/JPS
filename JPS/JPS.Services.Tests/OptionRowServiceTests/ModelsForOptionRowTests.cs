using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.OptionRowDTOs;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	public static class ModelsForOptionRowTests
	{
		public static QuestionEntity GetQuestionEntityModel(
			int id = 1,
			string text = "text",
			bool isRequired = true,
			int questionSectionId = 1,
			bool canHaveOtherOption = false,
			string comment = "comment",
			string imageUrl = null,
			string videoUrl = null,
			int order = 1,
			int questionTypeId = 8)
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

		public static OptionRowEntity GetOptionRowEntityModel(
			int id = 1,
			int questionId = 1,
			string text = "text",
			string imageUrl = null,
			int order = 1)
		{
			var optionEntity = new OptionRowEntity()
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order,
			};
			return optionEntity;
		}

		public static OptionRowDTO GetOptionRowDTOModel(
			int id = 1,
			int questionId = 1,
			string text = "text",
			string imageUrl = null,
			int order = 1)
		{
			var optionDTO = new OptionRowDTO()
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order,
			};
			return optionDTO;
		}
	}
}
