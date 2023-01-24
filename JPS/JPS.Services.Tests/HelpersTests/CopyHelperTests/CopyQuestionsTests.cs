using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	[TestClass]
	public class CopyQuestionsTests
	{
		[TestMethod]
		public void TestCopyQuestionsWithoutOptions_ShouldBePassed()
		{
			var questionEntities = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 1, questionSectionId: 1, order:1),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 2, questionSectionId: 1, order:2),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 3, questionSectionId: 1, order:3)
			};
			var expectedQuestions = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 1, order: 1),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 2, order: 2),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 3, order: 3)
			};

			var copiedQuestions = CopyHelper.CopyQuestions(questionEntities);

			var result = copiedQuestions
				.Zip(expectedQuestions, (first, second) => 
					new QuestionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyQuestionsWithOptions_ShouldBePassed()
		{
			var questionEntities = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 1,questionSectionId: 1, questionTypeId: 9, order: 1,
					options: new List<OptionEntity>
					{
						ModelsForCopyHelperTests.GetOptionEntity(id: 1), 
						ModelsForCopyHelperTests.GetOptionEntity(id: 2)
					},
					optionRows: new List<OptionRowEntity>
					{
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 1), 
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 2)
					}),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 2, questionSectionId: 1, questionTypeId: 9, order: 2,
					options: new List<OptionEntity>
					{
						ModelsForCopyHelperTests.GetOptionEntity(id: 3), 
						ModelsForCopyHelperTests.GetOptionEntity(id: 4)
					},
					optionRows: new List<OptionRowEntity>
					{
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 3), 
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 4)
					}),
			};
			var expectedQuestions = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, questionTypeId: 9, prototypeId: 1, order: 1,
					options: new List<OptionEntity>
					{
						ModelsForCopyHelperTests.GetOptionEntity(id: 0, questionId: 0), 
						ModelsForCopyHelperTests.GetOptionEntity(id: 0, questionId: 0)
					},
					optionRows: new List<OptionRowEntity>
					{
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 0, questionId: 0), 
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 0, questionId: 0)
					}),
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0,questionSectionId: 0, questionTypeId: 9, prototypeId: 2, order: 2,
					options: new List<OptionEntity>
					{
						ModelsForCopyHelperTests.GetOptionEntity(id: 0, questionId: 0), 
						ModelsForCopyHelperTests.GetOptionEntity(id: 0, questionId: 0)
					},
					optionRows: new List<OptionRowEntity>
					{
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 0, questionId: 0), 
						ModelsForCopyHelperTests.GetOptionRowEntity(id: 0, questionId: 0)
					}),
			};

			var copiedQuestions = CopyHelper.CopyQuestions(questionEntities);

			var result = copiedQuestions
				.Zip(expectedQuestions, (first, second) => 
					new QuestionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyQuestionsWithPrototype_ShouldBePassed()
		{
			var questionEntities = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 1,questionSectionId: 1, order:1, prototypeId: 3)
			};
			var expectedQuestions = new List<QuestionEntity>
			{
				ModelsForCopyHelperTests.GetQuestionEntity(id: 0,questionSectionId: 0, order:1, prototypeId:3),
			};

			var copiedQuestions = CopyHelper.CopyQuestions(questionEntities);

			var result = copiedQuestions
				.Zip(expectedQuestions, (first, second) => 
					new QuestionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyQuestions_CopyNullQuestions_ShouldBeNull()
		{
			var section = new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "section"
			};

			var result = CopyHelper.CopyQuestions(section.Questions);

			Assert.IsNull(result);
		}
	}
}
