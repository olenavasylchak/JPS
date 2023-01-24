using JPS.Infrastructure.Context;
using JPS.Services.Interfaces.Interfaces;
using Moq;

namespace JPS.Services.Tests.QuestionServiceTests
{
	public class QuestionServiceTestBase : ServiceTestBase
	{
		protected readonly Mock<IQuestionService> QuestionServiceMock = new Mock<IQuestionService>();

		protected JPSContext DbContext { get; set; }
		protected IQuestionService QuestionService { get; set; }
	}
}
