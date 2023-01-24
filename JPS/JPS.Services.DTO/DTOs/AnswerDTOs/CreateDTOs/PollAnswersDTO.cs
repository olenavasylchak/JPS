using JPS.Services.DTO.Attributes;
using JPS.Services.DTO.Enum;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs
{
	/// <summary>
	/// Model for creating new answer.
	/// </summary>
	public class PollAnswersDTO
	{
		public int QuestionId { get; set; }
		public string UserId { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.Time)]
		public CreateTimeAnswerDTO TimeAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.Date)]
		public CreateDateAnswerDTO DateAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.Paragraph)]
		public CreateParagraphAnswerDTO ParagraphAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.Text,
			(int)QuestionTypes.MultipleChoice, (int)QuestionTypes.CheckBoxes)]
		public CreateTextAnswerDTO TextAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.FileUpload)]
		public CreateFileAnswerDTO FileAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.LinearScale)]
		public IEnumerable<CreatePollOptionAnswerDTO> LinearScaleAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.Dropdown)]
		public IEnumerable<CreatePollOptionAnswerDTO> DropdownAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.CheckBoxes)]
		public IEnumerable<CreatePollOptionAnswerDTO> CheckBoxAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.MultipleChoice)]
		public IEnumerable<CreatePollOptionAnswerDTO> ChoiceAnswer { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.CheckboxGrid)]
		public IEnumerable<CreatePollOptionAnswerDTO> CheckBoxGridAnswers { get; set; }

		[AllowedQuestionTypes((int)QuestionTypes.MultipleChoiceGrid)]
		public IEnumerable<CreatePollOptionAnswerDTO> ChoiceGridAnswer { get; set; }
	}
}
