using JPS.API.IoC.SettingsModels;
using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.Interfaces.ModelInterfaces;
using Moq;

namespace JPS.Services.Tests.UtilsServiceTests
{
	public abstract class UtilsServiceTestsBase : ServiceTestBase
	{
		protected readonly Mock<IUtilsService> UtilsServiceMock = new Mock<IUtilsService>();
		protected readonly Mock<IAzureBlobStorageOptions> AzureBlobStorageOptionsMock = new Mock<IAzureBlobStorageOptions>();
		protected readonly IAzureBlobStorageOptions AzureBlobStorageOptions = new AzureBlobStorageOptions();

		protected JPSContext DbContext { get; set; }
		protected IUtilsService UtilsService { get; set; }
		
	}
}