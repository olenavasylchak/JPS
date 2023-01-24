using Hangfire;
using Hangfire.MemoryStorage;
using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServicePublishPollAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
			GlobalConfiguration.Configuration.UseMemoryStorage();
		}

		[TestMethod]
		public async Task PublishPoll_IntegrationTest()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: 1,
				startsAt: new DateTimeOffset(2020, 6, 6, 12, 0, 0, TimeSpan.FromHours(3)),
				questionSections:
				new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
					questions:
					new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
						questionTypeId: (int)QuestionTypes.CheckboxGrid,
						options:
						new List<OptionEntity>
						{
							new OptionEntity { Text = "test" },
							new OptionEntity { Text = "test 2" }
						},
						optionRows:
						new List<OptionRowEntity>
						{
							new OptionRowEntity { Text = "test" },
							new OptionRowEntity { Text = "test 2" }
						})
					})
				}
			);

			await AddItems(DbContext, pollEntity);

			var pollDTO = await PollService.PublishPollAsync(pollId);

			Assert.IsNotNull(pollDTO);
		}

		[TestMethod]
		public async Task TestPublishPollMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.PublishPollAsync(1);
			});
		}

		[TestMethod]
		[DynamicData(nameof(GetTestOptionsCountAndTypeData), DynamicDataSourceType.Method)]
		public async Task TestOptions_ShouldThrowException
			(
			string displayName,
			PollEntity pollEntity
			)
		{
			var pollId = 1;

			await AddItems(DbContext, pollEntity);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.PublishPollAsync(pollId);
			});
		}

		[TestMethod]
		[DynamicData(nameof(GetTestRowsCountAndTypeData), DynamicDataSourceType.Method)]
		public async Task TestRows_ShouldThrowException
			(
			string displayName,
			PollEntity pollEntity
			)
		{
			var pollId = 1;

			await AddItems(DbContext, pollEntity);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.PublishPollAsync(pollId);
			});
		}

		[TestMethod]
		public async Task TestPublishPollMethod_LinearScaleWithoutValue_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.LinearScale,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test", Value = 1 },
											new OptionEntity { Text = "test 2" }
										},
									optionRows:
										new List<OptionRowEntity>
										{
											new OptionRowEntity { Text = "test" },
											new OptionRowEntity { Text = "test 2" }
										})
								})
						}
				);

			await AddItems(DbContext, pollEntity);

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.PublishPollAsync(pollId);
			});
		}

		[TestMethod]
		public async Task TestPublishPollMethod_NullStartDateUpdated_ShouldBePassed()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   startsAt: null,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.LinearScale,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test", Value = 1 },
											new OptionEntity { Text = "test 2", Value = 2 }
										},
									optionRows:
										new List<OptionRowEntity>
										{
											new OptionRowEntity { Text = "test" },
											new OptionRowEntity { Text = "test 2" }
										})
								})
						}
				);

			await AddItems(DbContext, pollEntity);

			var pollDTO = await PollService.PublishPollAsync(pollId);

			Assert.IsNotNull(pollDTO.StartsAt);
		}

		private static IEnumerable<object[]> GetTestRowsCountAndTypeData()
		{
			yield return new object[]
			{
			   "Test case 1: PublishPoll_QuestionHasAnyRow_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.MultipleChoiceGrid,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" },
											new OptionEntity { Text = "test 2" }
										},
									optionRows:
										new List<OptionRowEntity> { }
									)
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 2: PublishPoll_QuestionHasOneRowAndTypeMultipleChoiceGrid_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.MultipleChoiceGrid,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" },
											new OptionEntity { Text = "test 2" }
										},
									optionRows:
										new List<OptionRowEntity>
										{
											new OptionRowEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 3: PublishPoll_QuestionHasOneRowAndTypeCheckboxGrid_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.CheckboxGrid,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" },
											new OptionEntity { Text = "test 2" }
										},
									optionRows:
										new List<OptionRowEntity>
										{
											new OptionRowEntity { Text = "test" }
										})
								})
						}
				)
			};
		}

		private static IEnumerable<object[]> GetTestOptionsCountAndTypeData()
		{
			yield return new object[]
			{
			   "Test case 1: PublishPoll_QuestionHasAnyOption_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.MultipleChoice,
									options:
										new List<OptionEntity> { })
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 2: PublishPoll_QuestionHasOneOptionAndTypeMultipleChoice_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.MultipleChoice,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 3: PublishPoll_QuestionHasOneOptionAndTypeCheckBoxes_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.CheckBoxes,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 4: PublishPoll_QuestionHasOneOptionAndTypeDropDown_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.Dropdown,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 5: PublishPoll_QuestionHasOneOptionAndTypeLinearScale_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.LinearScale,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 6: PublishPoll_QuestionHasOneOptionAndTypeCheckboxGrid_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.CheckboxGrid,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
			yield return new object[]
			{
			   "Test case 7: PublishPoll_QuestionHasOneOptionAndTypeMultipleChoiceGrid_ShouldThrowException",
			   ModelsForPollTests.GetPollEntityModel(
				   id: 1,
				   questionSections:
						new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
							questions:
								new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
									questionTypeId: (int)QuestionTypes.MultipleChoiceGrid,
									options:
										new List<OptionEntity>
										{
											new OptionEntity { Text = "test" }
										})
								})
						}
				)
			};
		}
	}
}
