using AutoMapper;
using JPS.API.IoC.MapperProfile;
using JPS.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests
{
	public abstract class ServiceTestBase
	{
		protected IMapper Mapper;

		public ServiceTestBase()
		{
			InitMapper();
		}

		protected JPSContext CreateDbContext()
		{

			var builder = new DbContextOptionsBuilder<JPSContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString()) // Use in memory database that exists in RAM when running tests.
				.EnableSensitiveDataLogging(); // Includes sensitive data, like Id, when exception thrown.

			// Create new JPSDbContext
			var context = new JPSContext(builder.Options);
			return context;
		}

		protected async Task AddItems<T>(JPSContext dbContext, params T[] entities)
			where T : class
		{

			foreach (var entity in entities)
			{

				await dbContext.Set<T>().AddAsync(entity);
				await dbContext.SaveChangesAsync();

				// Entity not being tracked by dbContext
				dbContext.Entry(entity).State = EntityState.Detached;
			}
		}

		private void InitMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<APIMapperProfile>();
				cfg.AddProfile<DomainMapperProfile>();
				cfg.AddProfile<ServicesMapperProfile>();
			});

			Mapper = config.CreateMapper();
		}
	}
}