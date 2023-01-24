using System;

namespace JPS.Services.Helpers
{
	public static class RecurringJobsHelper
	{
		public static string GetPollInProgressJobId(int pollId)
		{
			return String.Concat(ServiceConstants.PollInProgressJobIdPrefix, pollId);
		}
	}
}
