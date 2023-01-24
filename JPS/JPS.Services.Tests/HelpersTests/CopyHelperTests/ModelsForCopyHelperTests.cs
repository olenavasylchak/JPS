using JPS.Domain.Entities.Entities;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	public static class ModelsForCopyHelperTests
	{
		public static PollEntity GetPollEntity(
			int id = 1,
			int? categoryId = null,
			string title = "some text",
			string description = "",
			bool isAnonymous = false,
			DateTimeOffset? startsAt = null,
			DateTimeOffset? finishesAt = null,
			List<QuestionSectionEntity> questionSections = null)
		{
			var poll = new PollEntity
			{
				Id = id,
				CategoryId = categoryId,
				Title = title,
				Description = description,
				IsAnonymous = isAnonymous,
				StartsAt = startsAt,
				FinishesAt = finishesAt,
				QuestionSections = questionSections
			};

			return poll;
		}

		public static QuestionSectionEntity GetQuestionSectionEntity(
			int id = 1,
			int pollId = 1,
			string title = "someText",
			string description = "",
			int order = 1,
			List<QuestionEntity> questions = null
		)
		{
			var optionEntity = new QuestionSectionEntity()
			{
				Id = id,
				PollId = pollId,
				Title = title,
				Description = description,
				Order = order,
				Questions = questions
			};

			return optionEntity;
		}

		public static QuestionEntity GetQuestionEntity(
			int id = 1,
			int questionSectionId = 1,
			int questionTypeId = 1,
			string text = "someText",
			int? prototypeId = null,
			bool canHaveOtherOption = false,
			bool isRequired = false,
			string comment = "",
			string imageUrl = "img",
			string videoUrl = "vid",
			int order = 1,
			List<OptionEntity> options = null,
			List<OptionRowEntity> optionRows = null
		)
		{
			var optionEntity = new QuestionEntity
			{
				Id = id,
				QuestionSectionId = questionSectionId,
				QuestionTypeId = questionTypeId,
				Text = text,
				CanHaveOtherOption = canHaveOtherOption,
				IsRequired = isRequired,
				Comment = comment,
				ImageUrl = imageUrl,
				VideoUrl = videoUrl,
				PrototypeQuestionId = prototypeId,
				Order = order,
				Options = options,
				OptionRows = optionRows
			};

			return optionEntity;
		}

		public static OptionEntity GetOptionEntity(
			int id = 1,
			int questionId = 1,
			string text = "someText",
			string imageUrl = "img",
			int order = 1
		)
		{
			var optionEntity = new OptionEntity()
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order
			};

			return optionEntity;
		}

		public static OptionRowEntity GetOptionRowEntity(
			int id = 1,
			int questionId = 1,
			string text = "someText",
			string imageUrl = "img",
			int order = 1
		)
		{
			var optionEntity = new OptionRowEntity
			{
				Id = id,
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order
			};

			return optionEntity;
		}
	}
}
