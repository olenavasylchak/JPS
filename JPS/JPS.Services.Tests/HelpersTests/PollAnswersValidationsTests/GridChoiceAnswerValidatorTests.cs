using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Helpers.PollAnswersValidations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.PollAnswersValidationsTests
{
	[TestClass]
	public class GridChoiceAnswerValidatorTests
	{
		[TestMethod]
		public void GridChoiceAnswerValidator_GivenValidData_ShouldBePassed()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
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
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					},
					new OptionRowEntity
					{
						Id = 2,
						Text = "test option row 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = 2
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();
			Exception expectedException = null;

			try
			{
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO);
			}
			catch(Exception ex)
			{
				expectedException = ex;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateGridChoiceAnswer_GivenNullAnswerDTOAndRequiredQuestion_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, null));
		}

		[TestMethod]
		public void ValidateGridChoiceAnswer_GivenNullGridChoiceAnswerDTOAndRequiredQuestion_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = null
			};

			var gridCoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridCoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllQuestionRowsAnswered_GivenGridChoiceAnswerDTOWithLessRowsAnswersAndRequiredQuestion_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
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
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					},
					new OptionRowEntity
					{
						Id = 2,
						Text = "test option row 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = 1
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllAnswersHaveRow_GivenGridChoiceAnswerDTOWithoutRowsAnswers_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
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
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					},
					new OptionRowEntity
					{
						Id = 2,
						Text = "test option row 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = null
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = null
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateNotMoreThanOneOptionPerRowChecked_GivenGridChoiceAnswerDTOWithMoreThanOneoptionPerRow_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
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
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					},
					new OptionRowEntity
					{
						Id = 2,
						Text = "test option row 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = 2
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllRowsAreRelatedToQuestion_GivenOptionRowNotRelatedToQuestion_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
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
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = 2
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}

		[TestMethod]
		public void ValidateAllOptionsAreRelatedToQuestion_GivenOptionNotRelatedToQuestion_ShouldThrowException()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				IsRequired = true,
				QuestionTypeId = 8,
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Id = 1,
						Text = "test option 1"
					}
				},
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Id = 1,
						Text = "test option row 1"
					},
					new OptionRowEntity
					{
						Id = 2,
						Text = "test option row 2"
					}
				}
			};

			var pollAnswerDTO = new PollAnswersDTO
			{
				QuestionId = 1,
				UserId = "userId",
				ChoiceGridAnswer = new List<CreatePollOptionAnswerDTO>
				{
					new CreatePollOptionAnswerDTO
					{
						OptionId = 1,
						OptionRowId = 1
					},
					new CreatePollOptionAnswerDTO
					{
						OptionId = 2,
						OptionRowId = 2
					}
				}
			};

			var gridChoiceAnswerValidator = new GridChoiceAnswerValidator();

			Assert.ThrowsException<ArgumentException>(() =>
				gridChoiceAnswerValidator.ValidateAnswer(question, pollAnswerDTO));
		}
	}
}
