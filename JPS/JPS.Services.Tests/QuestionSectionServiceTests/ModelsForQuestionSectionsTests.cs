using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using System.Collections.Generic;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	public static class ModelsForQuestionSectionsTests
	{
		public static QuestionSectionEntity GetQuestionSectionEntityModel(
			int id = 1,
			int pollId = 1,
			string title = "title",
			string description = "description",
			int order = 1,
			List<QuestionEntity> questions = null,
			PollEntity poll = null
			)
		{
			var newQuestionSection = new QuestionSectionEntity
			{
				Id = id,
				PollId = pollId,
				Title = title,
				Description = description,
				Order = order,
				Questions = questions,
				Poll = poll
			};
			return newQuestionSection;
		}

		public static QuestionSectionDTO GetQuestionSectionDTOModel(
			int id = 1,
			int pollId = 1,
			string title = "title",
			string description = "description",
			int order = 1,
			List<QuestionDTO> questions = null
			)
		{
			var newQuestionSection = new QuestionSectionDTO
			{
				Id = id,
				PollId = pollId,
				Title = title,
				Description = description,
				Order = order,
				Questions = questions
			};
			return newQuestionSection;
		}

		public static QuestionEntity GetQuestionEntityModel(
			int id = 1,
			int questionSectionId = 1,
			string text = "text",
			string comment = "comment",
			int order = 1,
			bool canHaveOtherOptions = false,
			bool isRequired = false,
			int? prototypeQuestionId = 1,
			int questionTypeId = 1,
			string ImageUrl=null,
			string VideoUrl=null
			)
		{
			var newQuestionSection = new QuestionEntity
			{
				Id = id,
				QuestionSectionId =questionSectionId,
				Text = text,
				Comment = comment,
				Order = order,
				CanHaveOtherOption= canHaveOtherOptions,
				IsRequired= isRequired,
				PrototypeQuestionId=prototypeQuestionId,
				QuestionTypeId= questionTypeId,
				ImageUrl = ImageUrl,
				VideoUrl= VideoUrl,
			};
			return newQuestionSection;
		}
	}
}
