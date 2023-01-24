using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.OptionServiceTests
{
	public abstract class OptionServiceTestsBase : ServiceTestBase
	{
		protected readonly Mock<IOptionService> OptionServiceMock = new Mock<IOptionService>();
		protected JPSContext DbContext { get; set; }
		protected IOptionService OptionService { get; set; }
	}
}