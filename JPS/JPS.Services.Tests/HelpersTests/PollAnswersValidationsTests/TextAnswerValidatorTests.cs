using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class TextAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateTextAnswer_GivenNullTextAnswerDTO_ShouldThrowArgumentException()
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
				TextAnswer = null
			};

			var textAnswerValidator = new TextAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				textAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateTextAnswer_GivenEmptyStringText_ShouldThrowArgumentException()
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
				TextAnswer = new CreateTextAnswerDTO
				{
					Text = ""
				}
			};

			var textAnswerValidator = new TextAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				textAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateTextAnswer_GivenValidTextInput_ShouldBePassed()
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
				TextAnswer = new CreateTextAnswerDTO
				{
					Text = "text"
				}
			};

			Exception expectedException = null;

			var textAnswerValidator = new TextAnswerValidator();

			try
			{
				textAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
