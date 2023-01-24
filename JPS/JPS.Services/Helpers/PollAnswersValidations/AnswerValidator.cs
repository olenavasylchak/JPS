using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Abstract class for the main validation method.
	/// </summary>
	public abstract class AnswerValidator
	{
		/// <summary>
		/// Main validation method that call the validation for required questions and validate due to type.
		/// </summary>
		/// <param name="question">Uses to get the question that supposed to be answered.</param>
		/// <param name="pollAnswerDTO">Uses to get all the answers.</param>
		public void ValidateAnswer(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{

			if (pollAnswerDTO != null)
			{
				// Validation only for not trivial question type cases.
				ValidateDueToQuestionType(question, pollAnswerDTO);
				ValidateDueToOtherOptionFlag(question, pollAnswerDTO);
			}

			if (question.IsRequired)
			{
				if (pollAnswerDTO == null)
				{
					throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
				}
				ValidateRequiredQuestion(question, pollAnswerDTO);
			}
		}

		protected abstract void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO);

		protected virtual void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO) { }

		protected virtual void ValidateDueToOtherOptionFlag(QuestionEntity question, PollAnswersDTO pollAnswerDTO) { }
	}
}
