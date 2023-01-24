using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.Services.Tests.HelpersTests
{
	[TestClass]
	public class RecurringJobHelperTest
	{
		[TestMethod]
		public void GetRecuringPollInProgressJobJobId_GivePollId_PrefixAndPollIdShouldBeConnected()
		{
			string expected = "Poll-reminder-3";
			int pollId = 3;

			string result = RecurringJobsHelper.GetPollInProgressJobId(pollId);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
