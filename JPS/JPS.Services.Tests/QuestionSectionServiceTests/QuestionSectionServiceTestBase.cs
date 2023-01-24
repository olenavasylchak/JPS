using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	public abstract class QuestionSectionServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IQuestionSectionService> QuestionSectionServiceMock = new Mock<IQuestionSectionService>();
		protected JPSContext DbContext { get; set; }
		protected IQuestionSectionService QuestionSectionService { get; set; }
	}
}