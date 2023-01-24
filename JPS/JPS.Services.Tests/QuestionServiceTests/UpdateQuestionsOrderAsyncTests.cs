using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class UpdateQuestionsOrderAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionsOrderAsync_GivenInputToChangeQuestionsBetweenSections_ShouldBePassed()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = GetUpdateQuestionOrderBetweenSectionsDTOs();
			var actualQuestionDTOs = await QuestionService
				.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			var expectedQuestionDTOs = GetExpectedQuestionDTOsAfterSwappingQuestionsBetweenSections();

			var questionComparer = new QuestionDTOComparer();
			var result = actualQuestionDTOs.Zip(expectedQuestionDTOs,
					(first, second) => questionComparer.Compare(first, second))
				.FirstOrDefault(res => res != 0);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionsOrderAsync_GivenInputToChangeQuestionsOrderInsideOneSection_ShouldBePassed()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = GetUpdateQuestionOrderInsideOneSectionDTOs();
			var actualQuestionDTOs = await QuestionService
				.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			var expectedQuestionDTOs = GetExpectedQuestionDTOsAfterChangingQuestionsOrderInsideOneSection();

			var questionComparer = new QuestionDTOComparer();
			var result = actualQuestionDTOs.Zip(expectedQuestionDTOs,
					(first, second) => questionComparer.Compare(first, second))
				.FirstOrDefault(res => res != 0);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_GivenOrderDuplicateInOneSection_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_GivenIdDuplicate_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_UpdatedNotAllQuestionsInPoll_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_UpdatedQuestionFromDifferentPoll_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);
			var secondPollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Description = "Third section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "forth question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};
			await AddItems(DbContext, secondPollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 4,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_MoveQuestionToTheSectionFromDifferentPoll_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);
			var secondPollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Description = "Third section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "forth question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};
			await AddItems(DbContext, secondPollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 3,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_GivenSectionFromAnotherPoll_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);
			var secondPollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Description = "Third section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "forth question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};
			await AddItems(DbContext, secondPollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 3,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_GivenMoreQuestionsThanExistInPoll_ShouldThrowException()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);
			var secondPollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Description = "Third section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "forth question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};
			await AddItems(DbContext, secondPollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 4,
					SectionId = 2,
					Order = 2
				}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsOrderAsync_MoveAllQuestionsFromSectionToAnother_ShouldBePassed()
		{
			var pollEntity = GetPollEntity();
			await AddItems(DbContext, pollEntity);

			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 1,
					Order = 3
				}
			};

			var result = await QuestionService.UpdateQuestionsOrderAsync(updateQuestionOrderDTOs);
			Assert.IsNotNull(result);
		}

		private IEnumerable<QuestionDTO> GetExpectedQuestionDTOsAfterChangingQuestionsOrderInsideOneSection()
		{
			var questionDTOs = new List<QuestionDTO>
			{
				new QuestionDTO
				{
					Id = 1,
					QuestionSectionId = 1,
					Text = "first question",
					CanHaveOtherOption = false,
					IsRequired = false,
					Order = 2,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				},
				new QuestionDTO
				{
					Id = 2,
					QuestionSectionId = 1,
					Text = "second question",
					CanHaveOtherOption = false,
					IsRequired = false,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				},
				new QuestionDTO
				{
					Id = 3,
					QuestionSectionId = 2,
					Text = "third question",
					CanHaveOtherOption = false,
					IsRequired = true,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				}
			};

			return questionDTOs;
		}

		private IEnumerable<QuestionDTO> GetExpectedQuestionDTOsAfterSwappingQuestionsBetweenSections()
		{
			var questionDTOs = new List<QuestionDTO>
			{
				new QuestionDTO
				{
					Id = 2,
					QuestionSectionId = 1,
					Text = "second question",
					CanHaveOtherOption = false,
					IsRequired = false,
					Order = 2,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				},
				new QuestionDTO
				{
					Id = 3,
					QuestionSectionId = 1,
					Text = "third question",
					CanHaveOtherOption = false,
					IsRequired = true,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				},
				new QuestionDTO
				{
					Id = 1,
					QuestionSectionId = 2,
					Text = "first question",
					CanHaveOtherOption = false,
					IsRequired = false,
					Order = 1,
					QuestionTypeId = 6,
					ImageUrl = "image url",
					VideoUrl = "video url"
				}
			};

			return questionDTOs;
		}

		private IEnumerable<UpdateQuestionOrderDTO> GetUpdateQuestionOrderBetweenSectionsDTOs()
		{
			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 2,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 1,
					Order = 1
				}
			};

			return updateQuestionOrderDTOs;
		}

		private IEnumerable<UpdateQuestionOrderDTO> GetUpdateQuestionOrderInsideOneSectionDTOs()
		{
			var updateQuestionOrderDTOs = new List<UpdateQuestionOrderDTO>
			{
				new UpdateQuestionOrderDTO
				{
					Id = 1,
					SectionId = 1,
					Order = 2
				},
				new UpdateQuestionOrderDTO
				{
					Id = 2,
					SectionId = 1,
					Order = 1
				},
				new UpdateQuestionOrderDTO
				{
					Id = 3,
					SectionId = 2,
					Order = 1
				}
			};

			return updateQuestionOrderDTOs;
		}

		private PollEntity GetPollEntity()
		{
			var pollEntity = new PollEntity
			{
				QuestionSections = new List<QuestionSectionEntity>
				{
					new QuestionSectionEntity
					{
						Description = "first section",
						Order = 1,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "first question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							},
							new QuestionEntity
							{
								Text = "second question",
								CanHaveOtherOption = false,
								IsRequired = false,
								Order = 2,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					},
					new QuestionSectionEntity
					{
						Description = "second section",
						Order = 2,
						Questions = new List<QuestionEntity>
						{
							new QuestionEntity
							{
								Text = "third question",
								CanHaveOtherOption = false,
								IsRequired = true,
								Order = 1,
								QuestionTypeId = 6,
								ImageUrl = "image url",
								VideoUrl = "video url"
							}
						}
					}
				}
			};

			return pollEntity;
		}
	}
}
