using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class CheckBoxAnswerValidatorTests
	{
		[TestMethod]
		public void ValidateCheckBoxAnswer_GivenNullAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 4
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, null));
		}

		[TestMethod]
		public void ValidateCheckBoxAnswer_GivenNullChoiceAnswerDTOAndRequiredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 4
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				CheckBoxAnswer = null
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllOptionsAreRelatedToQuestion_GivenOptionNotRelatedToQuestion_ShouldThrowArgumentException()
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
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 3
					}
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerWhenQuestionCantHaveOtherOption_ShouldThrowArgumentException()
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
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenNullTextAnswerAndOptionWhenQuestionCantHaveOtherOption_ShouldThrowArgumentException()
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
				},
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateDueToOtherOptionFlag_GivenNullTextAnswerWhenQuestionCantHaveOtherOption_ShouldThrowArgumentException()
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
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
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

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();
			Exception expectedException = null;

			try
			{
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
		public void ValidateDueToOtherOptionFlag_GivenTextAnswerAndOptionAnswerWhenQuestionCanHaveOtherOption_ShouldBePassed()
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
				},
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();
			Exception expectedException = null;

			try
			{
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
		public void ValidateAtLeastOneOptionExist_GivenEmptyChoiceAnswersList_ShouldThrowArgumentException()
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
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>()
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateCheckBoxAnswer_GivenExistingOptionAnswer_ShouldBePassed()
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
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				CheckBoxAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1
					}
				}
			};

			var checkBoxAnswerValidator = new CheckBoxAnswerValidator();
			Exception expectedException = null;

			try
			{
				checkBoxAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
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
