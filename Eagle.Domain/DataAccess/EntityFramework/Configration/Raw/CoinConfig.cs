using Eagle.Domain.Entities.Raw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration.Raw
{
    public class CoinConfig : BaseConfig<CoinDM>
    {
        public override void Configure(EntityTypeBuilder<CoinDM> builder)
        {
            base.Configure(builder);

            builder.ToTable("Coin");

            builder.HasOne(x => x.User)
                .WithOne(x => x.Coin)
                .HasForeignKey<CoinDM>(x => x.UserId);
        }
    }
}
