using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	public abstract class OptionRowServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IOptionRowService> OptionRowServiceMock = new Mock<IOptionRowService>();
		protected JPSContext DbContext { get; set; }
		protected IOptionRowService OptionRowService { get; set; }

	}
}