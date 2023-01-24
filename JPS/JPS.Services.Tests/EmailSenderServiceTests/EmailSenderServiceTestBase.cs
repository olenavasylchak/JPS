using JPS.Infrastructure.Context;
using JPS.Services.DTO.DTOs.UserDTOs;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.ModelInterfaces;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.EmailSenderServiceTests
{
	public class EmailSenderServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IGraphService> GraphServiceMock = new Mock<IGraphService>();
		protected readonly Mock<ISendGridOptions> SendGridOptionsMock = new Mock<ISendGridOptions>();

		protected JPSContext DbContext { get; set; }
		protected IEmailSenderService EmailSenderService { get; set; }

		protected EmailSenderServiceTestBase()
		{
			InitSendGridOptions();
			InitGraph();
		}

		protected void InitSendGridOptions()
		{
			SendGridOptionsMock
			.Setup(_ => _.SendGridKey).Returns("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");

			SendGridOptionsMock.Setup(_ => _.EmailSender).Returns("jsp.jps.test@gmail.com");

			SendGridOptionsMock.Setup(_ => _.SendGridUser).Returns("Test");
		}

		protected void InitGraph()
		{
			GraphServiceMock.Setup(_ => _.GetListOfUsersAsync()).Returns(GetFakeUsersAsync());

			GraphServiceMock.Setup(_ => _.GetNumberOfUsersAsync()).Returns(GetFakeNumberOfUsersAsync());
		}

		private async Task<IEnumerable<UserDTO>> GetFakeUsersAsync()
		{
			var users = new List<UserDTO>
			{
				new UserDTO { Id = "1", Mail = "test1@test.test", Name = "Test1" },
				new UserDTO { Id = "2", Mail = "test2@test.test", Name = "Test2" }
			};

			return users;
		}

		private async Task<int> GetFakeNumberOfUsersAsync()
		{
			var users = await GetFakeUsersAsync();

			return users.Count();
		}
	}
}
