using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.PollServiceTests
{
	public static class ModelsForPollTests
	{
		public static PollEntity GetPollEntityModel(
			int id = 1,
			int? categoryId = 1,
			string title = "test title",
			string description = "description",
			bool isAnonymous = false,
			DateTimeOffset? finishesAt = null,
			DateTimeOffset? startsAt = null,
			List<QuestionSectionEntity> questionSections = null
		)
		{
			var pollEntity = new PollEntity
			{
				Id = id,
				CategoryId = categoryId,
				Title = title,
				Description = description,
				IsAnonymous = isAnonymous,
				FinishesAt = finishesAt,
				StartsAt = startsAt,
				QuestionSections = questionSections
			};
			return pollEntity;
		}

		public static QuestionSectionEntity GetQuestionSectionEntityModel(
			int id = 1,
			int pollId = 1,
			string title = "title",
			string description = "description",
			int order = 1,
			List<QuestionEntity> questions = null
			)
		{
			var newQuestionSection = new QuestionSectionEntity
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
			string comment = "commet",
			int order = 1,
			bool canHaveOtherOptions = false,
			bool isRequired = false,
			int? prototypeQuestionId = 1,
			int questionTypeId = 1,
			string ImageUrl = null,
			string VideoUrl = null,
			List<AnswerEntity> answers = null,
			List<OptionEntity> options = null,
			List<OptionRowEntity> optionRows = null
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
				Answers = answers,
				Options = options,
				OptionRows = optionRows
			};
			return newQuestionSection;
		}

		public static AnswerEntity GetAnswerEntityModel(
			int id = 1,
			int questionId = 1,
			string userId = "1"
			)
		{
			var newAnswer = new AnswerEntity
			{
				Id = id,
				QuestionId = questionId,
				UserId = userId
			};
			return newAnswer;
		}

		public static PaginationDTO GetPaginationDTO(
			int pageNumber = 0,
			int pageSize = 3
		)
		{
			var paginationDTO = new PaginationDTO
			{
				PageNumber = pageNumber,
				PageSize = pageSize
			};
			return paginationDTO;
		}
		public static CategoryEntity GetCategoryEntityModel(
			int id = 1,
			string title = "test title"
		)
		{
			var categoryEntity = new CategoryEntity
			{
				Id = id,
				Title = title
			};
			return categoryEntity;
		}

		public static CreatePollDTO GetCreatePollDTOModel(
			int? categoryId = 1,
			string title = "test title",
			string description = "description",
			DateTimeOffset? finishesAt = null,
			DateTimeOffset? startsAt = null
		)
		{
			var createPollDTO = new CreatePollDTO
			{
				CategoryId = categoryId,
				Title = title,
				Description = description,
				FinishesAt = finishesAt,
				StartsAt = startsAt
			};
			return createPollDTO;
		}

		public static PollDTO GetPollDTOModel(
			int id = 1,
			int? categoryId = 1,
			string title = "test title",
			string description = "description",
			bool isAnonymous = false,
			DateTimeOffset? finishesAt = null,
			DateTimeOffset? startsAt = null,
			List<QuestionSectionDTO> questionSections = null
		)
		{
			var pollDTO = new PollDTO
			{
				Id = id,
				CategoryId = categoryId,
				Title = title,
				Description = description,
				IsAnonymous = false,
				FinishesAt = finishesAt,
				StartsAt = startsAt,
				QuestionSections = questionSections
			};
			return pollDTO;
		}
	}
}
