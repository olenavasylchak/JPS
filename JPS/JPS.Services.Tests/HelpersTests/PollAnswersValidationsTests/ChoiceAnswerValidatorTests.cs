using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class ChoiceAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateChoiceAnswer_GivenNullAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, null));
		}

		[TestMethod]
		public void ValidateChoiceAnswer_GivenNullChoiceAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3
			};
			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceAnswer = null
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateNotMoreThanOneOptionChecked_GivenTwoOptionsChecked_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3
			};
			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>
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

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllOptionsAreRelatedToQuestion_GivenOptionNotRelatedToQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 3
					}
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerAndOptionAnswerWhenQuestionCanHaveOtherOption_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				},
				CanHaveOtherOption = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				TextAnswer = new CreateTextAnswerDTO
				{
					Text = "other answer"
				},
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerWithNullTextAndOptionAnswerWhenQuestionCanHaveOtherOption_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				},
				CanHaveOtherOption = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				TextAnswer = new CreateTextAnswerDTO
				{
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerWhenQuestionCanHaveOtherOption_ShouldBePassed()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 4,
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
				},
				CanHaveOtherOption = true
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				TextAnswer = new CreateTextAnswerDTO
				{
					Text = "other answer"
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();
			Exception expectedException = null;

			try
			{
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerWhenQuestionCantHaveOtherOption_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				},
				CanHaveOtherOption = false
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				TextAnswer = new CreateTextAnswerDTO
				{
					Text = "other answer"
				},
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAtLeastOneOptionExist_GivenEmptyChoiceAnswersList_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>()
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateChoiceAnswer_GivenExistingOptionAnswer_ShouldBePassed()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 3,
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
				ChoiceAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var choiceAnswerValidator = new ChoiceAnswerValidator();
			Exception expectedException = null;

			try
			{
				choiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
	}
}
