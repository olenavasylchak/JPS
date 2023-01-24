using System;

namespace JPS.Services.Exceptions
{
	/// <summary>
	/// The Exception that is throw when action is not allowed.
	/// </summary>
	[Serializable]
	public class NotAllowed : Exception
	{
		public NotAllowed()
		{
		}

		public NotAllowed(string message) : base(message)
		{
		}
	}
}