using System.Linq;
using System.Security.Claims;
using JPS.Services.Constants;
using JPS.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.Services.Tests.UserClaimsAccessorServiceTests
{
	[TestClass]
	public class UserClaimsAccessorTests : UserClaimsAccessorServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(
				new Claim[]
				{
					new Claim(ClaimTypes.Name, "fakeUserName"),
					new Claim(ClaimTypes.NameIdentifier, "fakeUserId")
				}));

			var context = new DefaultHttpContext
			{
				User = fakeUser
			};

			context.Request.Headers["Tenant-ID"] = "fakeTenantId";
			HttpContextAccessorMock.Setup(_ => _.HttpContext).Returns(context);

			UserClaimsService = new UserClaimsAccessorService(HttpContextAccessorMock.Object);
		}

		[TestMethod]
		public void GetUserNameClaimTest_GivenSameFakeHttpContext_ShouldBePassed()
		{
			var expectedUserName = HttpContextAccessorMock.Object.HttpContext.User?.Claims?
				.FirstOrDefault(claim => claim.Type == ServiceConstants.NameClaimType)?.Value;

			var actualUserName = UserClaimsService.Name;

			Assert.AreEqual(expectedUserName, actualUserName);
		}

		[TestMethod]
		public void GetUserIdClaimTest_GivenSameFakeHttpContext_ShouldBePassed()
		{
			var expectedUserName = HttpContextAccessorMock.Object.HttpContext.User?.Claims?
				.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

			var actualUserName = UserClaimsService.UserId;

			Assert.AreEqual(expectedUserName, actualUserName);
		}
	}
}
