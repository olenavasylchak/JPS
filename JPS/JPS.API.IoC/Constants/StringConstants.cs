namespace JPS.API.IoC.Constants
{
	public static class StringConstants
	{
		public static readonly string AppSettingsSection = "AppSettings";

		public static readonly string AzureAdSection = "AzureAd";
		public static readonly string SwaggerAdSection = "SwaggerClient";
		public static readonly string AzureBlobStorageSection = "AzureBlobStorage";

		public static readonly string UnauthorizedResponse = "Unauthorized";
		public static readonly string ForbiddenResponse = "Forbidden";
		public static readonly string TokenName = "aad-jwt";
		public static readonly string OauthString = "oauth2";
		public static readonly string BearerString = "Bearer";

		public static readonly string AzurePolicy = "AzurePolicy";
		public static readonly string CorsOriginsSubSection = "CorsOrigins";
		public static readonly string SecurityDefinitionName = "Authorization";

		public static readonly string BearerAuthorizationDescription
			= "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
			  "Enter 'Bearer' [space] and then your token in the text input below." +
			  "\r\n\r\nExample: 'Bearer 12345abcdef'";

		public static readonly string ContentTypeString = "application/json";
		public static readonly string XmlFileName = "JPS.API.xml";
		public static readonly string ApplicationTitle = "JPS API";
		public static readonly string ApiVersion = "v1";

		public static readonly string EmailAuthOptions = "EmailAuthOptions";
	}
}
