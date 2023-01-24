using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace JPS.Services.Tests.UserClaimsAccessorServiceTests
{
	public class UserClaimsAccessorServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IHttpContextAccessor> HttpContextAccessorMock = new Mock<IHttpContextAccessor>();
		protected readonly Mock<IUsersClaimsAccessorService> UserClaimsServiceMock = new Mock<IUsersClaimsAccessorService>();

		protected IUsersClaimsAccessorService UserClaimsService { get; set; }
	}
}
