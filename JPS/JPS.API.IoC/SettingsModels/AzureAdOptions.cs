using JPS.Services.Interfaces.ModelInterfaces;

namespace JPS.API.IoC.SettingsModels
{
    /// <summary>
    /// Model for Azure AD options.
    /// </summary>
    public class AzureAdOptions : IAzureAdOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string Scope { get; set; }
        public string ScopeDescription { get; set; }
    }
}