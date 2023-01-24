using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.Enums;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Static class to implement factory pattern.
	/// </summary>
	public static class AnswersValidatorFactory
	{
		/// <summary>
		/// Method to choose which validation to use for specific type.
		/// </summary>
		/// <param name="questionType">Uses to identify the type of the question.</param>
		/// <param name="context">Database context.</param>
		/// <returns> Specific object for validation.</returns>
		public static AnswerValidator Create(QuestionTypes questionType)
		{
			return questionType switch
			{
				QuestionTypes.Paragraph => new ParagraphAnswerValidator(),
				QuestionTypes.Text => new TextAnswerValidator(),
				QuestionTypes.Time => new TimeAnswerValidator(),
				QuestionTypes.Date => new DateAnswerValidator(),
				QuestionTypes.CheckBoxes => new CheckBoxAnswerValidator(),
				QuestionTypes.MultipleChoice => new ChoiceAnswerValidator(),
				QuestionTypes.CheckboxGrid => new GridCheckBoxAnswerValidator(),
				QuestionTypes.MultipleChoiceGrid => new GridChoiceAnswerValidator(),
				QuestionTypes.LinearScale => new LinearScaleAnswerValidator(),
				QuestionTypes.Dropdown => new DropDownAnswerValidator(),
				QuestionTypes.FileUpload => new FileAnswerValidator(),
				_ => throw new ArgumentException(ExceptionMessageConstants.UnsupportedQuestionTypeMessage)
			};
		}
	}
}
