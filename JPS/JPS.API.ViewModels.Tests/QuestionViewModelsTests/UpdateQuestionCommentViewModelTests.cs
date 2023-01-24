using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionCommentViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionText()
		{
			var updateQuestionCommentViewModel = new UpdateQuestionCommentViewModel
			{
				Comment = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(updateQuestionCommentViewModel.Comment, expected);
		}

		[TestMethod]
		public void TestUpdateQuestion_CommentLength250_ShouldBePassed()
		{
			var comment = new StringBuilder();
			for (int index = 0; index < 250; index++)
			{
				comment.Append("a");
			}

			var updateCommentViewModel = new UpdateQuestionCommentViewModel
			{
				Comment = comment.ToString()
			};

			var result = Validator.TryValidateObject(
				updateCommentViewModel,
				new ValidationContext(updateCommentViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestUpdateQuestion_CommentLength251_ShouldBeFailed()
		{
			var comment = new StringBuilder();
			for (int index = 0; index < 251; index++)
			{
				comment.Append("a");
			}

			var updateCommentViewModel = new UpdateQuestionCommentViewModel
			{
				Comment = comment.ToString()
			};

			var result = Validator.TryValidateObject(
				updateCommentViewModel,
				new ValidationContext(updateCommentViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}
	}
}
