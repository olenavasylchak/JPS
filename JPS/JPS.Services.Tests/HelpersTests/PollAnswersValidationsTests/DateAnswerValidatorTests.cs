using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class DateAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateDateAnswer_GivenNullPollAnswerDTO_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity() 
			{ 
				IsRequired = true 
			};

			PollAnswersDTO pollAnswerDTO = null;

			var dateAnswerValidator = new DateAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dateAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDateAnswer_GivenDefaultDate_ShouldThrowArgumentException()
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
				DateAnswer = new CreateDateAnswerDTO
				{
					Date = default
				}
			};

			var dateAnswerValidator = new DateAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dateAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDateAnswer_GivenValidDateInput_ShouldBePassed()
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
				DateAnswer = new CreateDateAnswerDTO
				{
					Date = new DateTime(2020, 10, 21)
				}
			};

			Exception expectedException = null;

			var dateAnswerValidator = new DateAnswerValidator();

			try
			{
				dateAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
