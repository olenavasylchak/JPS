using JPS.Services.Interfaces.ModelInterfaces;

namespace JPS.API.IoC.SettingsModels
{

    /// <summary>
    /// Model for Azure Blob Storage configuration
    /// </summary>
    public class AzureBlobStorageOptions: IAzureBlobStorageOptions
    {
        public string AccountName { get; set; }

        public string BlobUri { get; set; }

        public string AccountKey { get; set; }

    }
}
