using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	public class AnalyticsServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IAnalyticsService> AnalyticsServiceMock = new Mock<IAnalyticsService>();
		protected readonly Mock<IGraphService> FakeGraphServiceMock = new Mock<IGraphService>();
		protected JPSContext DbContext { get; set; }
		protected IAnalyticsService AnalyticsService { get; set; }
		protected IGraphService FakeGraphService { get; set; }
	}
}