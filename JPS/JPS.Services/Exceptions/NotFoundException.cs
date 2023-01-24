using System;
using System.Runtime.Serialization;

namespace JPS.Services.Exceptions
{
	/// <summary>
	/// The Exception that is throw when object is not found 
	/// </summary>
	[Serializable]
	public class NotFoundException : ApplicationException
	{
		public NotFoundException()
		{
		}

		public NotFoundException(string message) : base(message)
		{
		}

		public NotFoundException(string message, Exception inner) : base(message, inner)
		{
		}

		protected NotFoundException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}