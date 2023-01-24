using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class DropdownAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateDropDownAnswer_GivenExistingOptionAnswer_ShouldBePassed()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5,
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
				DropdownAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var dropdownAnswerValidator = new DropDownAnswerValidator();
			Exception expectedException = null;

			try
			{
				dropdownAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
		public void ValidateDropDownAnswer_GivenNullAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5
			};

			var dropdownAnswerValidator = new DropDownAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dropdownAnswerValidator.ValidateAnswer(question, null));
		}

		[TestMethod]
		public void ValidateDropDownAnswer_GivenNullDropdownAnswerDTOOnRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				DropdownAnswer = null
			};

			var dropdownAnswerValidator = new DropDownAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dropdownAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllOptionsAreRelatedToQuestion_GivenOptionNotRelatedToQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5,
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
				DropdownAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 3
					}
				}
			};

			var dropdownAnswerValidator = new DropDownAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dropdownAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAtLeastOneOptionExist_GivenEmptyDropdownAnswersList_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5,
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
				DropdownAnswer = new List<CreatePollOptionAnswerDTO>()
			};

			var dropdownAnswerValidator = new DropDownAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dropdownAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateNotMoreThanOneOptionChecked_GivenTwoDropdownAnswers_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 5,
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
				DropdownAnswer = new List<CreatePollOptionAnswerDTO>
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

			var dropdownAnswerValidator = new DropDownAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				dropdownAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}
	}
}
