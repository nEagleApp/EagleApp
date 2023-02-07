using Eagle.Domain.Entities.Raw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration.Raw
{
    internal class UserTokenConfig : BaseConfig<UserTokenDM>
    {
        public override void Configure(EntityTypeBuilder<UserTokenDM> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserTokens");

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTokens)
                .HasForeignKey(x => x.UserId);
        }
    }
}
