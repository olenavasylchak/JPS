using JPS.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Helpers
{
	/// <summary>
	/// Contains methods for copying objects.
	/// </summary>
	public static class CopyHelper
	{
		/// <summary>
		/// Copies options.
		/// </summary>
		/// <param name="options">Collection of options to be copied.</param>
		/// <returns>Copies of options.</returns>
		public static List<OptionEntity> CopyOptions(List<OptionEntity> options)
		{
			if (options is null)
			{
				return null;
			}
			var copiedOptions = new List<OptionEntity>(options
				.Select(option => new OptionEntity
				{
					Text = option.Text,
					ImageUrl = option.ImageUrl,
					Order = option.Order,
					Value = option.Value
				}));
			return copiedOptions;
		}

		/// <summary>
		/// Copies option rows.
		/// </summary>
		/// <param name="optionRows">Collection of option rows to be copied.</param>
		/// <returns>Copies of option rows.</returns>
		public static List<OptionRowEntity> CopyOptionRows(List<OptionRowEntity> optionRows)
		{
			if (optionRows is null)
			{
				return null;
			}
			var copiedOptionRows = new List<OptionRowEntity>(optionRows
				.Select(option => new OptionRowEntity
				{
					Text = option.Text,
					ImageUrl = option.ImageUrl,
					Order = option.Order,
				}));
			return copiedOptionRows;
		}

		/// <summary>
		/// Copies question sections.
		/// </summary>
		/// <param name="sections">Collection of question sections to be copied.</param>
		/// <returns>Copies of question section.</returns>
		public static List<QuestionSectionEntity> CopyQuestionSections(List<QuestionSectionEntity> sections)
		{
			if (sections is null)
			{
				return null;
			}
			var copiedQuestionSections = new List<QuestionSectionEntity>(sections
				.Select(section => new QuestionSectionEntity
				{
					Title = section.Title,
					Description = section.Description,
					Order = section.Order,
					Questions = CopyQuestions(section.Questions)
				}));

			return copiedQuestionSections;
		}

		/// <summary>
		/// Copies questions.
		/// </summary>
		/// <param name="questions">Collection of questions to be copied.</param>
		/// <returns>Copies of questions.</returns>
		public static List<QuestionEntity> CopyQuestions(List<QuestionEntity> questions)
		{
			if (questions is null)
			{
				return null;
			}
			var copiedQuestions = new List<QuestionEntity>(questions
				.Select(question => new QuestionEntity
				{
					Text = question.Text,
					CanHaveOtherOption = question.CanHaveOtherOption,
					IsRequired = question.IsRequired,
					Comment = question.Comment,
					Order = question.Order,
					QuestionTypeId = question.QuestionTypeId,
					ImageUrl = question.ImageUrl,
					VideoUrl = question.VideoUrl,
					Options = CopyOptions(question.Options),
					OptionRows = CopyOptionRows(question.OptionRows),
					PrototypeQuestionId = question.PrototypeQuestionId ?? (question.PrototypeQuestionId = question.Id),
					PrototypeQuestion = question.PrototypeQuestion ?? (question.PrototypeQuestion = question)

		}));
			return copiedQuestions;
		}

		/// <summary>
		/// Copies poll.
		/// </summary>
		/// <param name="poll">Poll to be copied.</param>
		/// <returns>Copy of poll.</returns>
		public static PollEntity CopyPoll(PollEntity poll)
		{
			if (poll is null)
			{
				return null;
			}
			var copiedPoll = new PollEntity
			{
				CategoryId = poll.CategoryId,
				Title = poll.Title,
				Description = poll.Description,
				IsAnonymous = poll.IsAnonymous,
				StartsAt = poll.StartsAt,
				FinishesAt = poll.FinishesAt,
				CreatedAt = poll.CreatedAt,
				QuestionSections = CopyQuestionSections(poll.QuestionSections),
				PollStyle = CopyPollStyle(poll.PollStyle)
			};

			return copiedPoll;
		}

		/// <summary>
		/// Copies poll style.
		/// </summary>
		/// <param name="style">Style to be copied.</param>
		/// <returns>Copy of pollStyle.</returns>
		public static PollStyleEntity CopyPollStyle(PollStyleEntity style)
		{
			if (style is null)
			{
				return null;
			}
			var copiedPollStyle = new PollStyleEntity
			{
				ThemeColor = style.ThemeColor,
				Opacity = style.Opacity,
				Font = style.Font,
				ImageUrl = style.ImageUrl,
				ImageXCoordinate = style.ImageXCoordinate,
				ImageYCoordinate = style.ImageYCoordinate
			};

			return copiedPollStyle;
		}
	}
}
