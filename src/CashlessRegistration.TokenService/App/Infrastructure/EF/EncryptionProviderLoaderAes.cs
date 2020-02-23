using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public class EncryptionProviderLoaderAes : IEncryptionProviderLoader
    {
        private readonly AesProvider _aesProvider;

        public EncryptionProviderLoaderAes()
        {
            //this configuration is just for test proposous. In real cases we need to load the keys from a secure location by environment maybe 
            var key = AesProvider.GenerateKey(AesKeySize.AES256Bits);
            var encryptionKey = key.Key;
            var encryptionIv = key.IV;
            _aesProvider = new AesProvider(encryptionKey, encryptionIv);
        }

        public IEncryptionProvider Load()
        {
            return _aesProvider;
        }
    }
}
