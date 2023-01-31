using Eagle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration
{
    public abstract class LibConfig<T> : BaseConfig<T> where T : LibEntityDM
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
