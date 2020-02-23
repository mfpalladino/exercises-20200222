namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public static class EncryptionProviderLoaderAesSingleton
    {
        private static readonly EncryptionProviderLoaderAes Instance = new EncryptionProviderLoaderAes();

        static EncryptionProviderLoaderAesSingleton()
        {
        }

        public static EncryptionProviderLoaderAes GetInstance()
        {
            return Instance;
        }
    }
}