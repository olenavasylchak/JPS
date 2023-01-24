using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.CategoryServiceTests
{
	public abstract class CategoryServiceTestsBase : ServiceTestBase
	{
		protected readonly Mock<ICategoryService> CategoryServiceMock = new Mock<ICategoryService>();
		protected ICategoryService CategoryService { get; set; }
		protected JPSContext DbContext { get; set; }
	}
}
