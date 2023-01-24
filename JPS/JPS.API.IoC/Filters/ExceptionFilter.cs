using JPS.API.IoC.Constants;
using JPS.Services.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace JPS.API.IoC.Filters
{
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		private readonly ILogger<ExceptionFilter> _logger;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public ExceptionFilter(ILogger<ExceptionFilter> logger, IWebHostEnvironment hostingEnvironment)
		{
			_logger = logger;
			_hostingEnvironment = hostingEnvironment;
		}

		public override void OnException(ExceptionContext context)
		{
			HttpStatusCode statusCode;
			var exception = context.Exception;

			if (exception is ArgumentNullException || exception is NotFoundException)
			{
				statusCode = HttpStatusCode.NotFound;
			}
			else if (exception is ArgumentException)
			{
				statusCode = HttpStatusCode.BadRequest;
			}
			else if (exception is InvalidOperationException)
			{
				statusCode = HttpStatusCode.MethodNotAllowed;
			}
			else if (exception is UnauthorizedAccessException)
			{
				statusCode = HttpStatusCode.Unauthorized;
			}
			else if (exception is NotAllowed)
			{
				statusCode = HttpStatusCode.MethodNotAllowed;
			}
			else
			{
				statusCode = HttpStatusCode.InternalServerError;
			}

			_logger.LogError(exception, exception.Message);

			context.HttpContext.Response.StatusCode = (int)statusCode;
			context.HttpContext.Response.ContentType = StringConstants.ContentTypeString;
			context.ExceptionHandled = true;
			string result;
			if (_hostingEnvironment.IsDevelopment())
			{
				result = JsonConvert.SerializeObject(exception);
			}
			else
			{
				result = JsonConvert.SerializeObject(exception.Message);
			}
			context.HttpContext.Response.WriteAsync(result);
			base.OnException(context);
		}
	}
}