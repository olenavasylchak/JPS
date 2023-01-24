using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Tests.HelpersTests.CopyHelperTests
{
	[TestClass]
	public class CopyOptionsTests
	{
		[TestMethod]
		public void TestCopyOptions_ShouldBePassed()
		{
			var optionEntities = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 3,questionId: 1, order:3)
			};
			var expectedOptions = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 0, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 0, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 0, order:3)
			};

			var copiedOptions = CopyHelper.CopyOptions(optionEntities);

			var result = copiedOptions
				.Zip(expectedOptions, (first, second) =>
					new OptionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void TestCopyOptions_CopyNullOptions_ShouldBeNull()
		{
			var question = new QuestionEntity
			{
				Id = 1,
				QuestionTypeId = 1,
				Text = "text"
			};
			var result = CopyHelper.CopyOptions(question.Options);

			Assert.IsNull(result);
		}



		[TestMethod]
		public void TestCopyOptions_ShouldNotCopyId()
		{
			var optionEntities = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 3,questionId: 1, order:3)
			};
			var expectedOptions = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 1,questionId: 0, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 2,questionId: 0, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 3,questionId: 0, order:3)
			};

			var copiedOptions = CopyHelper.CopyOptions(optionEntities);

			var result = copiedOptions
				.Zip(expectedOptions, (first, second) =>
					new OptionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreNotEqual(false, result);
		}

		[TestMethod]
		public void TestCopyOptions_ShouldNotCopyQuestionId()
		{
			var optionEntities = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 1,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 2,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 3,questionId: 1, order:3)
			};

			var expectedOptions = new List<OptionEntity>
			{
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 1, order:1),
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 1, order:2),
				ModelsForCopyHelperTests.GetOptionEntity(id: 0,questionId: 1, order:3)
			};

			var copiedOptions = CopyHelper.CopyOptions(optionEntities);

			var result = copiedOptions
				.Zip(expectedOptions, (first, second) =>
					new OptionEntityComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreNotEqual(false, result);
		}
	}
}
