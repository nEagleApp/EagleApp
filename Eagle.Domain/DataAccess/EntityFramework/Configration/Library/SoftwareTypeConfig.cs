using Eagle.Domain.Entities.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration.Library
{
    public class SoftwareTypeConfig : LibConfig<SoftwareTypeDM>
    {
        public override void Configure(EntityTypeBuilder<SoftwareTypeDM> builder)
        {
            base.Configure(builder);

            builder.ToTable("LibSoftwareType");
        }
    }
}
