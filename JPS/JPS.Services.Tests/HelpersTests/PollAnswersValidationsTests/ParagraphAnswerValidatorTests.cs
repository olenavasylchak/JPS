using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class ParagraphAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateParagraphAnswer_GivenNullParagraphAnswerDTO_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity()
			{
				Id = 1,
				IsRequired = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ParagraphAnswer = null
			};

			var paragraphAnswerValidator = new ParagraphAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				paragraphAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateParagraphAnswer_GivenEmptyStringText_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity()
			{
				Id = 1,
				IsRequired = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ParagraphAnswer = new CreateParagraphAnswerDTO
				{
					Text = ""
				}
			};

			var paragraphAnswerValidator = new ParagraphAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				paragraphAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateParagraphAnswer_GivenValidTextInput_ShouldBePassed()
		{
			var question = new QuestionEntity()
			{
				Id = 1,
				IsRequired = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ParagraphAnswer = new CreateParagraphAnswerDTO
				{
					Text = "text"
				}
			};

			Exception expectedException = null;

			var paragraphAnswerValidator = new ParagraphAnswerValidator();

			try
			{
				paragraphAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
			}
			catch (Exception ex)
			{
				expectedException = ex;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}
	}
}
