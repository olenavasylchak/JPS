using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.Common.Enums;
using System;

namespace JPS.API.ViewModels.Helpers
{
	/// <summary>
	/// Contains methods for calculating poll status.
	/// </summary>
	public static class PollStatusCalculator
	{
		/// <summary>
		/// Calculates poll status.
		/// </summary>
		/// <param name="poll">Poll which status needed to be calculated.</param>
		/// <returns>Poll status.</returns>
		public static PollStatuses CalculatePollStatus(PollViewModel poll)
		{
			if (poll.StartsAt is null)
			{
				return PollStatuses.Passive;
			}

			var currentDateTime = DateTimeOffset.Now;

			if (currentDateTime < poll.StartsAt)
			{
				return PollStatuses.SoonToBe;
			}

			if (poll.FinishesAt is null || currentDateTime <= poll.FinishesAt)
			{
				return PollStatuses.Active;
			}

			if (currentDateTime > poll.FinishesAt)
			{
				return PollStatuses.Ended;
			}

			return PollStatuses.Passive;
		}
	}
}
