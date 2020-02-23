using CashlessRegistration.TokenService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF.Map
{
    public class TokenRegistrationMap : IEntityTypeConfiguration<TokenRegistration>
    {
        public void Configure(EntityTypeBuilder<TokenRegistration> builder)
        {
            builder.ToTable("TokenRegistrations");
            builder.HasKey(x => new { x.Id });
            builder.Property(x => x.GeneratedAt).IsRequired();
            builder.Property(x => x.CardNumber).IsRequired();
        }
    }
}
