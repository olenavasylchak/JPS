using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.PollComparers;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	[TestClass]
	public class CopyPollTests
	{
		[TestMethod]
		public void TestCopyPoll_ShouldBePassed()
		{
			var pollEntity = ModelsForCopyHelperTests.GetPollEntity(
				questionSections: new List<QuestionSectionEntity>
				{
					ModelsForCopyHelperTests.GetQuestionSectionEntity(
						questions: new List<QuestionEntity>
						{
							ModelsForCopyHelperTests.GetQuestionEntity(
								options: new List<OptionEntity>
								{
									ModelsForCopyHelperTests.GetOptionEntity()
								},
								optionRows: new List<OptionRowEntity>
								{
									ModelsForCopyHelperTests.GetOptionRowEntity()
								})
						})
				});

			var expectedPoll = ModelsForCopyHelperTests.GetPollEntity(id: 0,
				questionSections: new List<QuestionSectionEntity>
				{
					ModelsForCopyHelperTests.GetQuestionSectionEntity(id: 0, pollId: 0,
						questions: new List<QuestionEntity>
						{
							ModelsForCopyHelperTests.GetQuestionEntity(id: 0, questionSectionId: 0, prototypeId: 1,
								options: new List<OptionEntity>
								{
									ModelsForCopyHelperTests.GetOptionEntity(id: 0, questionId: 0)
								},
								optionRows: new List<OptionRowEntity>
								{
									ModelsForCopyHelperTests.GetOptionRowEntity(id: 0, questionId: 0)
								})
						})
				});

			var result = CopyHelper.CopyPoll(pollEntity);

			Assert.AreEqual(0, new PollEntityComparer().Compare(expectedPoll, result));
		}
	}
}
