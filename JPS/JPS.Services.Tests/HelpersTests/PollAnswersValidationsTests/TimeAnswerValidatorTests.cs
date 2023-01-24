using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class TimeAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateTimeAnswer_GivenNullPollAnswerDTO_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity() 
			{ 
				IsRequired = true 
			};

			PollAnswersDTO pollAnswerDTO = null;

			var timeAnswerValidator = new TimeAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				timeAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateTimeAnswer_GivenDefaultTime_ShouldThrowArgumentException()
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
				TimeAnswer = new CreateTimeAnswerDTO
				{
					Time = default
				}
			};

			var timeAnswerValidator = new TimeAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				timeAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateTimeAnswer_GivenValidTimeInput_ShouldBePassed()
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
				TimeAnswer = new CreateTimeAnswerDTO
				{
					Time = new TimeSpan(12, 30, 00)
				}
			};

			Exception expectedException = null;

			var timeAnswerValidator = new TimeAnswerValidator();

			try
			{
				timeAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
