using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.PollServiceTests
{
	public abstract class PollServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IPollService> PollServiceMock = new Mock<IPollService>();
		protected readonly Mock<IEmailSenderService> EmailSenderServiceMock = new Mock<IEmailSenderService>();

		protected JPSContext DbContext { get; set; }
		protected IPollService PollService { get; set; }
	}
}
