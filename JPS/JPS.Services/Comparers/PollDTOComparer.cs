using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers
{
	public class PollDTOComparer : Comparer<PollDTO>
	{
		public override int Compare(PollDTO x, PollDTO y)
		{
			if(x is null && y is null)
			{
				return 0;
			}
			if (x is null)
			{
				return -1;
			}
			if (y is null)
			{
				return 1;
			}
			if (x.Id.CompareTo(y.Id) != 0)
			{
				return x.Id.CompareTo(y.Id);
			}
			if (x.IsAnonymous.CompareTo(y.IsAnonymous) != 0)
			{
				return x.Id.CompareTo(y.Id);
			}
			if (Nullable.Compare(x.CategoryId, y.CategoryId) != 0)
			{
				return Nullable.Compare(x.CategoryId, y.CategoryId);
			}
			if (string.Compare(x.Description, y.Description) != 0)
			{
				return string.Compare(x.Description, y.Description);
			}
			if (string.Compare(x.Title, y.Title) != 0)
			{
				return string.Compare(x.Title, y.Title);
			}
			if(Nullable.Compare(x.StartsAt, y.StartsAt) !=0)
			{
				return Nullable.Compare(x.StartsAt, y.StartsAt);
			}
			if (Nullable.Compare(x.FinishesAt, y.FinishesAt) != 0)
			{
				return Nullable.Compare(x.FinishesAt, y.FinishesAt);
			}
			if (DateTimeOffset.Compare(x.CreatedAt, y.CreatedAt) != 0)
			{
				return DateTimeOffset.Compare(x.CreatedAt, y.CreatedAt);
			}

			return 0;
		}
	}
}
