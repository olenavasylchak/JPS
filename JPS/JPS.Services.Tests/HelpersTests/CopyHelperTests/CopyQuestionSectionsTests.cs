using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	[TestClass]
	public class CopyQuestionSectionsTests
	{
		[TestMethod]
		public void TestCopyQuestionSectionsWithoutQuestions_ShouldBePassed()
		{
			var questionSectionEntities = new List<QuestionSectionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 1, pollId: 1, order:1),
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 2, pollId: 1, order:2)
			};
			var expectedQuestionSections = new List<QuestionSectionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 0, pollId: 0, order:1),
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 0, pollId: 0, order:2)
			};

			var copiedOptions = CopyHelper.CopyQuestionSections(questionSectionEntities);

			var result = copiedOptions
				.Zip(expectedQuestionSections, (first, second) => 
					new QuestionSectionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyQuestionSectionsWithQuestions_ShouldBePassed()
		{
			var questionSectionEntities = new List<QuestionSectionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 1, pollId: 1, order:1,
					questions: new List<QuestionEntity>
					{
						ModelsForCopyHelperTests.GetQuestionEntity(id: 1, prototypeId:3),
						ModelsForCopyHelperTests.GetQuestionEntity(id: 2)
					}),
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 2, pollId: 1, order:2,
					questions: new List<QuestionEntity>
						{
							ModelsForCopyHelperTests.GetQuestionEntity(id: 3),
							ModelsForCopyHelperTests.GetQuestionEntity(id: 4)

						})
			};

			var expectedQuestionSections = new List<QuestionSectionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 0, pollId: 0, order:1,
					questions: new List<QuestionEntity>
					{
						ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 3),
						ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 2)
					}),
				ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 0, pollId: 0, order:2,
					questions: new List<QuestionEntity>
					{
						ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 3),
						ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 4)
					})
			};

			var copiedOptions = CopyHelper.CopyQuestionSections(questionSectionEntities);

			var result = copiedOptions
				.Zip(expectedQuestionSections, (first, second) => 
					new QuestionSectionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyQuestionSections_CopyNullSections_ShouldBeNull()
		{
			var poll = new PollEntity
			{
				Id = 1,
				Title = "poll"
			};

			var result = CopyHelper.CopyQuestionSections(poll.QuestionSections);

			Assert.IsNull(result);
		}
	}
}
