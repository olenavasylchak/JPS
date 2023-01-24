using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class LinearScaleAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateLinearScaleAnswer_GivenExistingOptionAnswer_ShouldBePassed()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7,
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Id = 1,
						Text = "test option 1"
					},
					new OptionEntity
					{
						Id = 2,
						Text = "test option 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				LinearScaleAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();
			Exception expectedException = null;

			try
			{
				linearScaleAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateLinearScaleAnswer_GivenNullAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				linearScaleAnswerValidator.ValidateAnswer(question, null));
		}

		[TestMethod]
		public void ValidateLinearScaleAnswer_GivenNullLinearScaleAnswerDTOOnRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				LinearScaleAnswer = null
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				linearScaleAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllOptionsAreRelatedToQuestion_GivenOptionNotRelatedToQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7,
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Id = 1,
						Text = "test option 1",
						Value = 1
					},
					new OptionEntity
					{
						Id = 2,
						Text = "test option 2",
						Value = 5
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				LinearScaleAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 3
					}
				}
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				linearScaleAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAtLeastOneOptionExist_GivenEmptyLinearScaleAnswersList_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7,
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Id = 1,
						Text = "test option 1"
					},
					new OptionEntity
					{
						Id = 2,
						Text = "test option 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				LinearScaleAnswer = new List<CreatePollOptionAnswerDTO>()
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				linearScaleAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateNotMoreThanOneOptionChecked_GivenTwoLinearScaleAnswers_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 7,
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Id = 1,
						Text = "test option 1"
					},
					new OptionEntity
					{
						Id = 2,
						Text = "test option 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				LinearScaleAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2
					}
				}
			};

			var linearScaleAnswerValidator = new LinearScaleAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				linearScaleAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}
	}
}
