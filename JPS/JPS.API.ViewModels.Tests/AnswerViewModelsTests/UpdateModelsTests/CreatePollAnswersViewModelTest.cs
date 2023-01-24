using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.UpdateModelsTests
{
	[TestClass]
	public class CreatePollAnswersViewModelTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestCreatePollAnswersViewModelData), DynamicDataSourceType.Method)]
		public void TestCreatePollAnswers_PollId(string displayName, int pollId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreatePollAnswersViewModel(pollId: pollId);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreatePollAnswersViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreatePollAnswersViewModel_GivenNegativePollId_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreatePollAnswersViewModel_GivenZeroPollId_ShouldBeFailed",
				0
			};
		}

		private static CreatePollAnswersViewModel GetCreatePollAnswersViewModel(int pollId = 1)
		{
			TimeSpan time = new TimeSpan(4, 20, 0);
			DateTimeOffset date = new DateTimeOffset(new DateTime(2020, 07, 21, 08, 32, 00));

			List<CreateOptionAnswerViewModel> optionAnswers = new List<CreateOptionAnswerViewModel>
			{
				new CreateOptionAnswerViewModel()
				{
					OptionId = 1
				},
				new CreateOptionAnswerViewModel()
				{
					OptionId = 3
				}
			};

			List<CreateGridOptionAnswerViewModel> gridOptionAnswers = new List<CreateGridOptionAnswerViewModel>
			{
				new CreateGridOptionAnswerViewModel()
				{
					OptionId = 1,
					OptionRowId = 3
				},
				new CreateGridOptionAnswerViewModel()
				{
					OptionId = 3,
					OptionRowId = 5
				}
			};

			List<PollAnswersViewModel> pollAnswers = new List<PollAnswersViewModel>
			{
				new PollAnswersViewModel()
				{
					QuestionId = 1,
					TimeAnswer = new CreateTimeAnswerViewModel
					{
						Time = time
					}
				},
				new PollAnswersViewModel()
				{
					QuestionId = 2,
					TextAnswer = new CreateTextAnswerViewModel
					{
						Text = "text"
					}
				},
				new PollAnswersViewModel()
				{
					QuestionId = 3,
					ParagraphAnswer = new CreateParagraphAnswerViewModel
					{
						Text = "text"
					}
				},
				new PollAnswersViewModel()
				{
					QuestionId = 4,
					FileAnswer = new CreateFileAnswerViewModel
					{
						FileUrl = "url"
					}
				},
				new PollAnswersViewModel()
				{
					QuestionId = 5,
					DateAnswer = new CreateDateAnswerViewModel
					{
						Date = date
					}
				},
				new PollAnswersViewModel()
				{
					QuestionId = 6,
					LinearScaleAnswer = optionAnswers
				},
				new PollAnswersViewModel()
				{
					QuestionId = 7,
					CheckBoxGridAnswers = gridOptionAnswers
				}
			};
			var createPollAnswersModel = new CreatePollAnswersViewModel
			{
				PollId = pollId,
				Answers = pollAnswers
			};

			return createPollAnswersModel;
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenTextAnswerTwiceSameQuestion_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TextAnswer = new CreateTextAnswerViewModel
						{
							Text = "sometext1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TextAnswer = new CreateTextAnswerViewModel
						{
							Text = "sometext2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenParagraphAnswerTwiceSameQuestion_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ParagraphAnswer = new CreateParagraphAnswerViewModel
						{
							Text = "sometext1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ParagraphAnswer = new CreateParagraphAnswerViewModel
						{
							Text = "sometext2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenDateAnswerTwiceSameQuestion_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						DateAnswer = new CreateDateAnswerViewModel
						{
							Date = new DateTime(2020, 07, 22, 08, 32, 00)
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						DateAnswer = new CreateDateAnswerViewModel
						{
							Date = new DateTime(2020, 10, 05, 08, 32, 00)
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenTimeAnswerTwiceSameQuestion_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TimeAnswer = new CreateTimeAnswerViewModel
						{
							Time = new TimeSpan(4, 20, 0)
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TimeAnswer = new CreateTimeAnswerViewModel
						{
							Time = new TimeSpan(0, 0, 0)
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenFileAnswerTwiceSameQuestion_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						FileAnswer = new CreateFileAnswerViewModel
						{
							FileUrl = "url1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						FileAnswer = new CreateFileAnswerViewModel
						{
							FileUrl = "url2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenTextAnswerTwiceDifferentQuestions_ShouldBePassed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TextAnswer = new CreateTextAnswerViewModel
						{
							Text = "sometext1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 2,
						TextAnswer = new CreateTextAnswerViewModel
						{
							Text = "sometext2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenParagraphAnswerTwiceDifferentQuestions_ShouldBePassed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ParagraphAnswer = new CreateParagraphAnswerViewModel
						{
							Text = "sometext1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 2,
						ParagraphAnswer = new CreateParagraphAnswerViewModel
						{
							Text = "sometext2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenDateAnswerTwiceDifferentQuestions_ShouldBePassed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						DateAnswer = new CreateDateAnswerViewModel
						{
							Date = new DateTime(2020, 07, 22, 08, 32, 00)
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 2,
						DateAnswer = new CreateDateAnswerViewModel
						{
							Date = new DateTime(2020, 10, 05, 08, 32, 00)
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenTimeAnswerTwiceDifferentQuestions_ShouldBePassed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						TimeAnswer = new CreateTimeAnswerViewModel
						{
							Time = new TimeSpan(4, 20, 0)
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 2,
						TimeAnswer = new CreateTimeAnswerViewModel
						{
							Time = new TimeSpan(0, 0, 0)
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenFileAnswerTwiceDifferentQuestions_ShouldBePassed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						FileAnswer = new CreateFileAnswerViewModel
						{
							FileUrl = "url1"
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 2,
						FileAnswer = new CreateFileAnswerViewModel
						{
							FileUrl = "url2"
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenLinearScaleAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						LinearScaleAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						LinearScaleAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenCheckboxAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						CheckBoxAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						CheckBoxAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenChoiceAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ChoiceAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ChoiceAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestCreatePollAnswerViewModel_GivenDropDownAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						DropdownAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						DropdownAnswer = new List<CreateOptionAnswerViewModel>()
						{
							new CreateOptionAnswerViewModel()
							{
								OptionId = 1
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestPollAnswerViewModel_GivenChoiceGridAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ChoiceGridAnswer = new List<CreateGridOptionAnswerViewModel>()
						{
							new CreateGridOptionAnswerViewModel()
							{
								OptionId = 1,
								OptionRowId = 3
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						ChoiceGridAnswer = new List<CreateGridOptionAnswerViewModel>()
						{
							new CreateGridOptionAnswerViewModel()
							{
								OptionId = 1,
								OptionRowId = 3
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		public void TestPollAnswerViewModel_GivenCheckBoxGridAnswerTwiceSameOptions_ShouldBeFailed()
		{
			var model = new CreatePollAnswersViewModel()
			{
				PollId = 1,
				Answers = new List<PollAnswersViewModel>
				{
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						CheckBoxGridAnswers = new List<CreateGridOptionAnswerViewModel>()
						{
							new CreateGridOptionAnswerViewModel()
							{
								OptionId = 1,
								OptionRowId = 3
							}
						}
					},
					new PollAnswersViewModel()
					{
						QuestionId = 1,
						CheckBoxGridAnswers = new List<CreateGridOptionAnswerViewModel>()
						{
							new CreateGridOptionAnswerViewModel()
							{
								OptionId = 1,
								OptionRowId = 3
							}
						}
					}
				}
			};
			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

			Assert.IsFalse(actual, "Expects validation to fail");
		}
	}
}
