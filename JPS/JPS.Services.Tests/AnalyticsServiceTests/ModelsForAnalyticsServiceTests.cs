using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	public static class ModelsForAnalyticsServiceTests
	{
		/// <summary>
		/// Poll with 1 section with 7 questions(text, paragraph, option, file, date, time, grid).
		/// Each question has answers.
		/// </summary>
		public static PollEntity GetPollWithAnswersModel(
			int id = 1,
			string title = "poll",
			bool isAnonymous = false)
		{
			var pollWithAnswers = new PollEntity
			{
				Id = id,
				Title = title,
				IsAnonymous = isAnonymous,
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Title = "section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "question1",
								Order = 1,
								CanHaveOtherOption = false,
								QuestionTypeId = 1,
								Answers = new List<AnswerEntity>
								{
									GetTextAnswerModel("answer1", "user1"),
									GetTextAnswerModel("answer2", "user2")
								}
							},
							new QuestionEntity
							{
								Text = "question2",
								Order = 2,
								CanHaveOtherOption = false,
								QuestionTypeId = 2,
								Answers = new List<AnswerEntity>
								{
									GetParagraphAnswerModel("answer3", "user3"),
									GetParagraphAnswerModel("answer4", "user2")
								}
							},
							new QuestionEntity
							{
								Text = "question3",
								Order = 3,
								CanHaveOtherOption = false,
								QuestionTypeId = 3,
								Options = new List<OptionEntity>
								{
									GetOptionModel(1, 1, "option1"),
									GetOptionModel(2, 2, "option2")
								},
								Answers = new List<AnswerEntity>
								{
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 1
											}
										},
										UserId = "user1"

									},
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 1
											},
											new OptionAnswerEntity
											{
												OptionId = 2
											}
										},
										UserId = "user2"
									}
								}
							},
							new QuestionEntity
							{
								Text = "question4",
								Order = 4,
								CanHaveOtherOption = false,
								QuestionTypeId = 6,
								Answers = new List<AnswerEntity>
								{
									GetFileAnswerModel(),
									GetFileAnswerModel("file2", "user4")
								}
							},
							new QuestionEntity
							{
								Text = "question5",
								Order = 5,
								CanHaveOtherOption = false,
								QuestionTypeId = 10,
								Answers = new List<AnswerEntity>
								{
									GetDateAnswerModel(new DateTimeOffset(
										2020, 05, 24, 0, 0, 0,
										new TimeSpan(0, 3, 0))),
									GetDateAnswerModel(new DateTimeOffset(
										2020, 05, 24, 0, 0, 0,
										new TimeSpan(0, 3, 0)), "user2"),
									GetDateAnswerModel(new DateTimeOffset(
										2020, 05, 25, 0, 0, 0,
										new TimeSpan(0, 3, 0)), "user3")
								}
							},
							new QuestionEntity
							{
								Text = "question6",
								Order = 6,
								CanHaveOtherOption = false,
								QuestionTypeId = 11,
								Answers = new List<AnswerEntity>
								{
									GetTimeAnswerModel(new TimeSpan(10, 10, 10)),
									GetTimeAnswerModel(new TimeSpan(12, 12, 12), "user2"),
									GetTimeAnswerModel(new TimeSpan(12, 12, 12), "user3"),

								}
							},
							new QuestionEntity
							{
								Text = "question6",
								Order = 7,
								CanHaveOtherOption = false,
								QuestionTypeId = 9,
								Options = new List<OptionEntity>
								{
									GetOptionModel(3, 1, "option1"),
									GetOptionModel(4, 2, "option2")
								},
								OptionRows = new List<OptionRowEntity>
								{
									GetOptionRowModel(1, 1, "row1"),
									GetOptionRowModel(2, 2, "row2")
								},
								Answers = new List<AnswerEntity>
								{
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 3,
												OptionRowId = 1
											}
										},
										UserId = "user1"

									},
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 3,
												OptionRowId = 1
											},
											new OptionAnswerEntity
											{
												OptionId = 4,
												OptionRowId = 2
											}
										},
										UserId = "user2"
									}
								}
							}
						}

					}
				}
			};
			return pollWithAnswers;
		}

		private static OptionEntity GetOptionModel(int id = 1, int order = 1, string text = "option1")
		{
			var option = new OptionEntity
			{
				Id = id,
				Order = order,
				Text = text,
			};
			return option;
		}

		private static OptionRowEntity GetOptionRowModel(int id = 1, int order = 1, string text = "row1")
		{
			var option = new OptionRowEntity
			{
				Id = id,
				Order = order,
				Text = text
			};
			return option;
		}

		private static AnswerEntity GetTimeAnswerModel(TimeSpan time, string userId = "user1")
		{
			return new AnswerEntity
			{
				TimeAnswer = new TimeAnswerEntity
				{
					Time = time
				},
				UserId = userId

			};
		}

		private static AnswerEntity GetDateAnswerModel(
			DateTimeOffset date,
			string userId = "user1"
		)
		{
			return new AnswerEntity
			{
				DateAnswer = new DateAnswerEntity
				{
					Date = date
				},
				UserId = userId

			};
		}

		private static AnswerEntity GetTextAnswerModel(
			string text = "answer",
			string userId = "user1")
		{
			return new AnswerEntity
			{
				TextAnswer = new TextAnswerEntity
				{
					Text = text
				},
				UserId = userId
			};
		}

		private static AnswerEntity GetParagraphAnswerModel(
			string text = "answer1",
			string userId = "user1")
		{
			return new AnswerEntity
			{
				ParagraphAnswer = new ParagraphAnswerEntity
				{
					Text = text
				},
				UserId = userId
			};
		}

		private static AnswerEntity GetFileAnswerModel(
			string file = "file1",
			string userId = "user1")
		{
			return new AnswerEntity
			{
				FileAnswer = new FileAnswerEntity
				{
					FileUrl = file
				},
				UserId = userId
			};
		}

		public static GroupedAnswerDTO GetGroupedTextModel()
		{
			var textAnswers = new GroupedAnswerDTO
			{
				TextAnswers = new GroupedTextAnswerDTO()
				{
					TextAnswers = new List<TextAnswerDTO>
					{
						new TextAnswerDTO
						{
							Text = "answer1"
						},
						new TextAnswerDTO
						{
							Text = "answer2"
						}
					}
				}
			};
			return textAnswers;
		}

		public static GroupedAnswerDTO GetGroupedParagraphModel()
		{
			var paragraphAnswers = new GroupedAnswerDTO
			{
				ParagraphAnswers = new GroupedParagraphAnswerDTO()
				{
					ParagraphAnswers = new List<ParagraphAnswerDTO>
					{
						new ParagraphAnswerDTO
						{
							Text = "answer3"
						},
						new ParagraphAnswerDTO
						{
							Text = "answer4"
						}
					}
				}
			};
			return paragraphAnswers;
		}

		public static GroupedAnswerDTO GetGroupedOptionModel()
		{
			var optionAnswers = new GroupedAnswerDTO
			{
				OptionAnswers = new List<GroupedOptionAnswerDTO>
				{
					new GroupedOptionAnswerDTO
					{
						Count = 2,
						PercentageToAll = 33.33,
						PercentageToAlreadyAnswered = 100,
						OptionAnswer = new OptionDTO
						{
							Id = 1,
							QuestionId = 3,
							Order = 1,
							Text = "option1"
						}
					},
					new GroupedOptionAnswerDTO
					{
						Count = 1,
						PercentageToAll = 16.67,
						PercentageToAlreadyAnswered = 50,
						OptionAnswer = new OptionDTO
						{
							Id = 2,
							QuestionId = 3,
							Order = 2,
							Text = "option2"
						}
					}
				}
			};
			return optionAnswers;
		}

		public static GroupedAnswerDTO GetGroupedFileModel()
		{
			var fileAnswers = new GroupedAnswerDTO
			{
				FileAnswers = new GroupedFileAnswerDTO()
				{
					FileAnswers = new List<FileAnswerDTO>
					{
						new FileAnswerDTO
						{
							FileUrl = "file1"
						},
						new FileAnswerDTO
						{
							FileUrl = "file2"
						}
					}
				}
			};
			return fileAnswers;
		}

		public static GroupedAnswerDTO GetGroupedDateModel()
		{
			var dateAnswers = new GroupedAnswerDTO
			{
				DateAnswers = new List<GroupedDateAnswerDTO>
				{
					new GroupedDateAnswerDTO
					{
						DateAnswer = new DateAnswerDTO
						{
							Date = new DateTimeOffset(
								2020, 05, 24, 0, 0, 0,
								new TimeSpan(0, 3, 0))
						},
						Count = 2,
						PercentageToAll = 33.33,
						PercentageToAlreadyAnswered = 66.67,
					},
					new GroupedDateAnswerDTO
					{
						DateAnswer = new DateAnswerDTO
						{
							Date = new DateTimeOffset(
								2020, 05, 25, 0, 0, 0,
								new TimeSpan(0, 3, 0))
						},
						Count = 1,
						PercentageToAll = 16.67,
						PercentageToAlreadyAnswered = 33.33
					}
				}
			};
			return dateAnswers;
		}

		public static GroupedAnswerDTO GetGroupedTimeModel()
		{
			var timeAnswers = new GroupedAnswerDTO
			{
				TimeAnswers = new List<GroupedTimeAnswerDTO>
				{
					new GroupedTimeAnswerDTO
					{
						TimeAnswer = new TimeAnswerDTO
						{
							Time = new TimeSpan(10, 10, 10)
						},
						Count = 1,
						PercentageToAll = 16.67,
						PercentageToAlreadyAnswered = 33.33,
					},
					new GroupedTimeAnswerDTO
					{
						TimeAnswer = new TimeAnswerDTO
						{
							Time = new TimeSpan(12, 12, 12)
						},
						Count = 2,
						PercentageToAll = 33.33,
						PercentageToAlreadyAnswered = 66.67
					}
				}
			};
			return timeAnswers;
		}

		public static GroupedAnswerDTO GetGroupedGridModel()
		{
			var gridAnswers = new GroupedAnswerDTO
			{
				GridAnswers = new List<GroupedGridAnswerDTO>
				{
					new GroupedGridAnswerDTO
					{
						OptionRow = new OptionRowDTO
						{
							Id = 1,
							QuestionId = 7,
							Order = 1,
							Text = "row1"
						},
						OptionAnswers = new List<GroupedOptionAnswerDTO>
						{
							new GroupedOptionAnswerDTO
							{
								Count = 2,
								PercentageToAll = 33.33,
								PercentageToAlreadyAnswered = 100,
								OptionAnswer = new OptionDTO
								{
									Id = 3,
									QuestionId = 7,
									Order = 1,
									Text = "option1"
								}
							},
							new GroupedOptionAnswerDTO
							{
								Count = 0,
								PercentageToAll = 0,
								PercentageToAlreadyAnswered = 0,
								OptionAnswer = new OptionDTO
								{
									Id = 4,
									QuestionId = 7,
									Order = 2,
									Text = "option2"
								}
							}
						}
					},
					new GroupedGridAnswerDTO
					{
						OptionRow = new OptionRowDTO
						{
							Id = 2,
							QuestionId = 7,
							Order = 2,
							Text = "row2"
						},
						OptionAnswers = new List<GroupedOptionAnswerDTO>
						{
							new GroupedOptionAnswerDTO
							{
								Count = 0,
								PercentageToAll = 0,
								PercentageToAlreadyAnswered = 0,
								OptionAnswer = new OptionDTO
								{
									Id = 3,
									QuestionId = 7,
									Order = 1,
									Text = "option1"
								}
							},
							new GroupedOptionAnswerDTO
							{
								Count = 1,
								PercentageToAll = 16.67,
								PercentageToAlreadyAnswered = 50,
								OptionAnswer = new OptionDTO
								{
									Id = 4,
									QuestionId = 7,
									Order = 2,
									Text = "option2"
								}
							}
						}
					}
				}
			};
			return gridAnswers;
		}

		public static QuestionAnalyticsDTO GetQuestionAnalyticsModel(
			int id = 1,
			int questionSectionId = 1,
			string text = "question1",
			int order = 1,
			bool canHaveOtherOption = false,
			int questionTypeId = 1,
			int? prototypeId = null,
			GroupedAnswerDTO answers = null)
		{
			var question = new QuestionAnalyticsDTO
			{
				Id = id,
				QuestionSectionId = questionSectionId,
				Text = text,
				Order = order,
				CanHaveOtherOption = canHaveOtherOption,
				QuestionTypeId = questionTypeId,
				PrototypeQuestionId = prototypeId,
				GroupedAnswers = answers
			};
			return question;
		}
		public static PollAnalyticsDTO GetPollAnalyticsModel()
		{
			var poll = new PollAnalyticsDTO
			{
				Id = 1,
				Title = "poll",
				IsAnonymous = false,
				Progress = 0.67,
				Questions = new List<QuestionAnalyticsDTO>
						{
							GetQuestionAnalyticsModel(
								id : 1,
								questionSectionId : 1,
								text : "question1",
								order : 1,
								canHaveOtherOption : false,
								questionTypeId : 1,
								answers : GetGroupedTextModel()),
							GetQuestionAnalyticsModel(
								id : 2,
								questionSectionId : 1,
								text : "question2",
								order : 2,
								canHaveOtherOption : false,
								questionTypeId : 2,
								answers : GetGroupedParagraphModel()),
							GetQuestionAnalyticsModel(
								id : 3,
								questionSectionId : 1,
								text : "question3",
								order : 3,
								canHaveOtherOption : false,
								questionTypeId : 3,
								answers : GetGroupedOptionModel()),
							GetQuestionAnalyticsModel(
								id : 4,
								questionSectionId : 1,
								text : "question4",
								order : 4,
								canHaveOtherOption : false,
								questionTypeId : 6,
								answers : GetGroupedFileModel()),
							GetQuestionAnalyticsModel(
								id : 5,
								questionSectionId : 1,
								text : "question5",
								order : 5,
								canHaveOtherOption : false,
								questionTypeId : 10,
								answers : GetGroupedDateModel()),
							GetQuestionAnalyticsModel(
								id : 6,
								questionSectionId : 1,
								text : "question6",
								order : 6,
								canHaveOtherOption : false,
								questionTypeId : 11,
								answers : GetGroupedTimeModel()),
							GetQuestionAnalyticsModel(
								id : 7,
								questionSectionId : 1,
								text : "question6",
								order : 7,
								canHaveOtherOption : false,
								questionTypeId : 9,
								answers : ModelsForAnalyticsServiceTests.GetGroupedGridModel()),
						}
			};
			return poll;
		}

		public static PollEntity GetFirstPollToCompareModel()
		{
			var pollWithAnswers = new PollEntity
			{
				Id = 1,
				Title = "poll1",
				IsAnonymous = false,
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Id = 1,
						Title = "section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Id = 1,
								Text = "question1",
								Order = 1,
								CanHaveOtherOption = false,
								QuestionTypeId = 3,
								Options = new List<OptionEntity>
								{
									GetOptionModel(1,1,"option1"),
									GetOptionModel(2,2,"option2")
								},
								Answers = new List<AnswerEntity>
								{
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 1
											}
										},
										UserId = "user1"

									},
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 1
											},
											new OptionAnswerEntity
											{
												OptionId = 2
											}
										},
										UserId = "user2"
									}
								}
							},
							new QuestionEntity
							{
								Id = 2,
								Text = "question2",
								Order = 2,
								CanHaveOtherOption = false,
								QuestionTypeId = 11,
								Answers = new List<AnswerEntity>
								{
									GetTimeAnswerModel(new TimeSpan(10, 10, 10)),
									GetTimeAnswerModel(new TimeSpan(12, 12, 12), "user2"),
									GetTimeAnswerModel(new TimeSpan(12, 12, 12), "user3"),

								}
							},
						}

					}
				}
			};
			return pollWithAnswers;
		}

		public static PollEntity GetSecondPollToCompareModel()
		{
			var pollWithAnswers = new PollEntity
			{
				Id = 2,
				Title = "poll2",
				IsAnonymous = false,
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Id = 2,
						Title = "section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Id = 3,
								Text = "question1",
								Order = 1,
								CanHaveOtherOption = false,
								QuestionTypeId = 3,
								PrototypeQuestionId = 1,
								Options = new List<OptionEntity>
								{
									GetOptionModel(3,1,"option1"),
									GetOptionModel(4,2,"option2")
								},
								Answers = new List<AnswerEntity>
								{
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 3
											}
										},
										UserId = "user1"

									},
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 3
											},
											new OptionAnswerEntity
											{
												OptionId = 4
											}
										},
										UserId = "user2"
									},
									new AnswerEntity
									{
										OptionAnswers = new List<OptionAnswerEntity>
										{
											new OptionAnswerEntity
											{
												OptionId = 4
											}
										},
										UserId = "user4"
									}
								}
							},
							new QuestionEntity
							{
								Id = 4,
								Text = "question2",
								Order = 2,
								CanHaveOtherOption = false,
								QuestionTypeId = 11,
								Answers = new List<AnswerEntity>
								{
									GetTimeAnswerModel(new TimeSpan(10, 10, 10)),
								}
							},
						}

					}
				}
			};
			return pollWithAnswers;
		}

		public static PollComparisonDTO GetPollComparisonModel()
		{
			var pollComparison = new PollComparisonDTO
			{
				FirstPoll = new PollAnalyticsWithoutQuestionsDTO
				{
					Id = 1,
					Title = "poll1",
					IsAnonymous = false,
					Progress = 0.5
				},
				SecondPoll = new PollAnalyticsWithoutQuestionsDTO
				{
					Id = 2,
					Title = "poll2",
					IsAnonymous = false,
					Progress = 0.5
				},
				Questions = new List<IEnumerable<QuestionAnalyticsDTO>>
				{
					new List<QuestionAnalyticsDTO>
					{
						GetQuestionAnalyticsModel(
							id : 1,
							questionSectionId : 1,
							text : "question1",
							order : 1,
							canHaveOtherOption : false,
							questionTypeId : 3,
							answers : new GroupedAnswerDTO
							{
								OptionAnswers = new List<GroupedOptionAnswerDTO>
								{
									new GroupedOptionAnswerDTO
									{
										Count = 2,
										PercentageToAll = 33.33,
										PercentageToAlreadyAnswered = 100,
										OptionAnswer = new OptionDTO
										{
											Id = 1,
											QuestionId = 1,
											Order = 1,
											Text = "option1"
										}
									},
									new GroupedOptionAnswerDTO
									{
										Count = 1,
										PercentageToAll = 16.67,
										PercentageToAlreadyAnswered = 50,
										OptionAnswer = new OptionDTO
										{
											Id = 2,
											QuestionId = 1,
											Order = 2,
											Text = "option2"
										}
									}
								}
							}),
						GetQuestionAnalyticsModel(
							id : 2,
							questionSectionId : 1,
							text : "question2",
							order : 2,
							canHaveOtherOption : false,
							questionTypeId : 11,
							answers : new GroupedAnswerDTO
							{
								TimeAnswers = new List<GroupedTimeAnswerDTO>
								{
									new GroupedTimeAnswerDTO
									{
										TimeAnswer = new TimeAnswerDTO
										{
											Time = new TimeSpan(10, 10, 10)
										},
										Count = 1,
										PercentageToAll = 16.67,
										PercentageToAlreadyAnswered = 33.33,
									},
									new GroupedTimeAnswerDTO
									{
										TimeAnswer = new TimeAnswerDTO
										{
											Time = new TimeSpan(12, 12, 12)
										},
										Count = 2,
										PercentageToAll = 33.33,
										PercentageToAlreadyAnswered = 66.67,
									}
								}
							}),
						GetQuestionAnalyticsModel(
							id : 4,
							questionSectionId : 2,
							text : "question2",
							order : 2,
							canHaveOtherOption : false,
							questionTypeId : 11,
							answers : new GroupedAnswerDTO
							{
								TimeAnswers = new List<GroupedTimeAnswerDTO>
								{
									new GroupedTimeAnswerDTO
									{
										TimeAnswer = new TimeAnswerDTO
										{
											Time = new TimeSpan(10, 10, 10)
										},
										Count = 1,
										PercentageToAll = 16.67,
										PercentageToAlreadyAnswered = 100,
									}
								}
							})
					},
					new List<QuestionAnalyticsDTO>
					{
						GetQuestionAnalyticsModel(
							id : 3,
							questionSectionId : 2,
							text : "question1",
							order : 1,
							canHaveOtherOption : false,
							questionTypeId : 3,
							prototypeId: 1,
							answers : new GroupedAnswerDTO
							{
								OptionAnswers = new List<GroupedOptionAnswerDTO>
								{
									new GroupedOptionAnswerDTO
									{
										Count = 2,
										PercentageToAll = 33.33,
										PercentageToAlreadyAnswered = 66.67,
										OptionAnswer = new OptionDTO
										{
											Id = 4,
											QuestionId = 3,
											Order = 2,
											Text = "option2"
										}
									},
									new GroupedOptionAnswerDTO
									{
										Count = 2,
										PercentageToAll = 33.33,
										PercentageToAlreadyAnswered = 66.67,
										OptionAnswer = new OptionDTO
										{
											Id = 3,
											QuestionId = 3,
											Order = 1,
											Text = "option1"
										}
									}
								}
							})
					}
				}
			};
			return pollComparison;
		}
	}
}