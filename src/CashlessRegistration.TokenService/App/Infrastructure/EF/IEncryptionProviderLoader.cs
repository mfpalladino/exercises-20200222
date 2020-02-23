using Microsoft.EntityFrameworkCore.DataEncryption;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public interface IEncryptionProviderLoader
    {
        IEncryptionProvider Load();
    }
}