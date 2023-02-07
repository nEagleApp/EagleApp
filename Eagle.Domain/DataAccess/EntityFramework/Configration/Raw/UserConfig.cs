using Eagle.Domain.Entities.Raw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration.Raw
{
    public class UserConfig : BaseConfig<UserDM>
    {
        public override void Configure(EntityTypeBuilder<UserDM> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.HasMany(x => x.CoinRecords)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Coin)
                .WithOne(x => x.User)
                .HasForeignKey<UserDM>(x => x.Id);

            builder.HasMany(x => x.UserTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
