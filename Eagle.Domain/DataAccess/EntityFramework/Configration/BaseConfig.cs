using Eagle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eagle.Domain.DataAccess.EntityFramework.Configration
{
    public abstract class BaseConfig<T> : IEntityTypeConfiguration<T> where T : EntityDM
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }

}
