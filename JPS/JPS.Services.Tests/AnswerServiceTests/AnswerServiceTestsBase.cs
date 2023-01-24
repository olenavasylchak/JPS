using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace JPS.Services.Tests.AnswerServiceTests
{
	public abstract class AnswerServiceTestsBase : ServiceTestBase
	{
		protected readonly Mock<IHttpContextAccessor> HttpContextAccessorMock = new Mock<IHttpContextAccessor>();
		protected readonly Mock<IAnswerService> AnswerServiceMock = new Mock<IAnswerService>();
		protected readonly Mock<IUsersClaimsAccessorService> UserClaimsServiceMock = new Mock<IUsersClaimsAccessorService>();

		protected IUsersClaimsAccessorService UserClaimsService { get; set; }
		protected IAnswerService AnswerService { get; set; }
		protected JPSContext DbContext { get; set; }
	}
}
