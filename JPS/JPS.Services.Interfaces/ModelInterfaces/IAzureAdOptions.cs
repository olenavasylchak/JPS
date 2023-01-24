namespace JPS.Services.Interfaces.ModelInterfaces
{
	/// <summary>
	/// Azure options interface, holds the properties for Azure AD options.
	/// </summary>
	public interface IAzureAdOptions
	{
		public string ClientId { get; }
		public string ClientSecret { get; }
		public string Instance { get; }
		public string Domain { get; }
		public string TenantId { get; }
		public string Scope { get; }
		public string ScopeDescription { get; }
	}
}
