using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	[TestClass]
	public class CopyOptionRowsTests
	{
		[TestMethod]
		public void TestCopyOptionRows_ShouldBePassed()
		{
			var optionRowEntities = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 3,questionId: 1, order:3)
			};

			var expectedOptionRows = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 0, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 0, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 0, order:3)
			};

			var copiedOptionRows = CopyHelper.CopyOptionRows(optionRowEntities);

			var result = copiedOptionRows
				.Zip(expectedOptionRows, (first, second) =>
					new OptionRowEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyOptionRows_CopyNullOptionRows_ShouldBeNull()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				QuestionTypeId = 1,
				Text = "text"
			};
			var result = CopyHelper.CopyOptionRows(question.OptionRows);

			Assert.IsNull(result);
		}

		[TestMethod]
		public void TestCopyOptionRows_ShouldNotCopyId()
		{
			var optionEntities = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 3,questionId: 1, order:3)
			};
			var expectedOptionRows = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 1,questionId: 0, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 2,questionId: 0, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 3,questionId: 0, order:3)
			};

			var copiedOptions = CopyHelper.CopyOptionRows(optionEntities);

			var result = copiedOptions
				.Zip(expectedOptionRows, (first, second) =>
					new OptionRowEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreNotEqual(false, result);
		}

		[TestMethod]
		public void TestCopyOptionRows_ShouldNotCopyQuestionId()
		{
			var optionEntities = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 3,questionId: 1, order:3)
			};

			var expectedOptionRows = new List<OptionRowEntity>
			{
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionRowEntity(id: 0,questionId: 1, order:3)
			};

			var copiedOptions = CopyHelper.CopyOptionRows(optionEntities);

			var result = copiedOptions
				.Zip(expectedOptionRows, (first, second) =>
					new OptionRowEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreNotEqual(false, result);
		}
	}
}
