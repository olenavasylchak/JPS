using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.API.IoC.MapperProfile.AnswerConverter
{
	/// <summary>
	/// Class to convert PollAnswerDTO to AnswerEntity.
	/// </summary>
	public class AnswerEntityConverter : ITypeConverter<PollAnswersDTO, AnswerEntity>
	{
		public AnswerEntity Convert(PollAnswersDTO source, AnswerEntity destination, ResolutionContext context)
		{
			var answerEntity = new AnswerEntity();
			answerEntity.QuestionId = source.QuestionId;
			answerEntity.UserId = source.UserId;

			if (source.DateAnswer != null)
			{
				answerEntity.DateAnswer = context.Mapper
					.Map<DateAnswerEntity>(source.DateAnswer);
			}

			if (source.TimeAnswer != null)
			{
				answerEntity.TimeAnswer = context.Mapper
					.Map<TimeAnswerEntity>(source.TimeAnswer);
			}

			if (source.ParagraphAnswer != null)
			{
				answerEntity.ParagraphAnswer = context.Mapper
					.Map<ParagraphAnswerEntity>(source.ParagraphAnswer);
			}

			if (source.TextAnswer != null)
			{
				answerEntity.TextAnswer = context.Mapper
					.Map<TextAnswerEntity>(source.TextAnswer);
			}

			if (source.FileAnswer != null)
			{
				answerEntity.FileAnswer = context.Mapper
					.Map<FileAnswerEntity>(source.FileAnswer);
			}

			if(source.ChoiceAnswer != null)
			{
				if (source.ChoiceAnswer.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.ChoiceAnswer);
				}
			}

			if (source.CheckBoxAnswer != null)
			{
				if (source.CheckBoxAnswer.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.CheckBoxAnswer);
				}
			}

			if (source.CheckBoxGridAnswers != null)
			{
				if (source.CheckBoxGridAnswers.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.CheckBoxGridAnswers);
				}
			}

			if (source.ChoiceGridAnswer != null)
			{
				if (source.ChoiceGridAnswer.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.ChoiceGridAnswer);
				}
			}

			if (source.LinearScaleAnswer != null)
			{
				if (source.LinearScaleAnswer.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.LinearScaleAnswer);
				}
			}

			if (source.DropdownAnswer != null)
			{
				if (source.DropdownAnswer.Any())
				{
					answerEntity.OptionAnswers = context.Mapper
						.Map<List<OptionAnswerEntity>>(source.DropdownAnswer);
				}
			}
			return answerEntity;
		}
	}
}
