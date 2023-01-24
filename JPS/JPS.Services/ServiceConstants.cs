namespace JPS.Services
{
	public static class ServiceConstants
	{
		public static readonly int MinimalNumberOfQuestionSectionInPollValue = 1;
		public static readonly int MinimalNumberOfOptionsInQuestion = 2;
		public static readonly int MinimalNumberOfOptionRowsInQuestion = 2;
		public static readonly int RoundingFactor = 2;
		public static readonly int NumberOfPollsToBeCompared = 2;
		public static readonly string AzureAdSection = "AzureAd";
		public static readonly string BearerString = "Bearer";
		public static readonly string DefaultScopeString = "https://graph.microsoft.com/.default";
		public static readonly string PollInProgressJobIdPrefix = "Poll-reminder-";

		public static readonly string StartPollEmailViewPath =
			"/EmailNotifications/PollStartEmailView.html";
		public static readonly string PollInProgressEmailViewPath =
			"/EmailNotifications/PollInProgressEmailView.html";
		public static readonly string EndPollEmailViewPath =
			"/EmailNotifications/PollEndEmailView.html";
		public static readonly string CronExpressionPollReminder =
			"0 0 14 1/3 * ?";
		public static readonly string NameClaimType = "name";
	}
}
