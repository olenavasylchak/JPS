using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class FileAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateFileAnswer_GivenNullFileAnswerDTO_ShouldThrowArgumentException()
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
				FileAnswer = null
			};

			var fileAnswerValidator = new FileAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				fileAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateFileAnswer_GivenEmptyStringFileUrl_ShouldThrowArgumentException()
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
				FileAnswer = new CreateFileAnswerDTO
				{
					FileUrl = ""
				}
			};

			var fileAnswerValidator = new FileAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				fileAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateFileAnswer_GivenValidFileInput_ShouldBePassed()
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
				FileAnswer = new CreateFileAnswerDTO
				{
					FileUrl = "file url"
				}
			};

			Exception expectedException = null;

			var fileAnswerValidator = new FileAnswerValidator();

			try
			{
				fileAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
