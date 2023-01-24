using JPS.Domain.Entities.Entities;
using System;

namespace JPS.Services.Tests.EmailSenderServiceTests
{
	public static class ModelsForEmailSenderTests
	{
		public static PollEntity GetPollEntityModel(
			int id = 1,
			int? categoryId = null,
			string description = "Test",
			string title = "Test",
			bool isAnonymous = false)
		{
			var pollEntity = new PollEntity
			{
				Id = id,
				CategoryId = categoryId,
				CreatedAt = DateTime.Now,
				StartsAt = DateTime.Now,
				Description = description,
				Title = title,
				IsAnonymous = isAnonymous
			};
			return pollEntity;

		}
	}
}
