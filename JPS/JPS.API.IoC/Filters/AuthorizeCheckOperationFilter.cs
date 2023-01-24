using JPS.API.IoC.Constants;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net;

namespace JPS.API.IoC.Filters
{
	/// <summary>
	/// Filter for authorization using Swagger.
	/// </summary>
	public class AuthorizeCheckOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			operation.Responses.Add(HttpStatusCode.Unauthorized.ToString(),
				new OpenApiResponse { Description = StringConstants.UnauthorizedResponse });
			operation.Responses.Add(HttpStatusCode.Forbidden.ToString(),
				new OpenApiResponse { Description = StringConstants.ForbiddenResponse });

			operation.Security = new List<OpenApiSecurityRequirement>
			{
				new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme,
								Id = StringConstants.TokenName
							},
							Scheme = StringConstants.OauthString,
							Name = StringConstants.TokenName,
							In = ParameterLocation.Header
						},
						new List<string>()
					}
				},

				new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference=new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id=StringConstants.BearerString
							},
							Scheme=StringConstants.OauthString,
							Name=StringConstants.BearerString,
							In=ParameterLocation.Header
						},
						new List<string>()
					}
				}
			};
		}
	}
}