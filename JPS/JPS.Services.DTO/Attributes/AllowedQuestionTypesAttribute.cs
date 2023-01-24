using System;

namespace JPS.Services.DTO.Attributes
{
	public class AllowedQuestionTypesAttribute : Attribute
	{
		public int[] Values { get; set; }

		public AllowedQuestionTypesAttribute(params int[] values)
		{
			this.Values = values;
		}
	}
}
