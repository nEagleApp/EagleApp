using Eagle.Domain.Entities.Raw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration.Raw
{
    public class CoinRecordConfig : BaseConfig<CoinRecordDM>
    {
        public override void Configure(EntityTypeBuilder<CoinRecordDM> builder)
        {
            base.Configure(builder);

            builder.ToTable("CoinRecords");

            builder.HasOne(x => x.User)
                .WithMany(x => x.CoinRecords)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.SoftwareType)
                .WithMany()
                .HasForeignKey(x => x.SoftwareTypeId);
        }
    }
}
