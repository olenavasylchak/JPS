namespace JPS.Services.Interfaces.ModelInterfaces
{
    public interface IAzureBlobStorageOptions
    {
        string AccountName { get; }

        string BlobUri { get; }

        string AccountKey { get; }

    }
}
