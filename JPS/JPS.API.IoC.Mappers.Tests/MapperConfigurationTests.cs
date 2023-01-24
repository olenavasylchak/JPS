using AutoMapper;
using JPS.API.IoC.MapperProfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.IoC.Mappers.Tests
{
	[TestClass]
	public class MapperConfigurationTests
	{
		[TestMethod]
		public void TestMapperConfiguration()
		{
			var config = new MapperConfiguration(cfg =>
			   {
				   cfg.AddProfile<APIMapperProfile>();
				   cfg.AddProfile<DomainMapperProfile>();
				   cfg.AddProfile<ServicesMapperProfile>();
			   });

			config.AssertConfigurationIsValid();
		}
	}
}
