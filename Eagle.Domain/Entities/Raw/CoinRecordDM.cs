using Eagle.Domain.Entities.Library;

namespace Eagle.Domain.Entities.Raw
{
    public class CoinRecordDM : EntityDM
    {
        public int UserId { get; set; }
        public int SoftwareTypeId { get; set; }
        public int EarnCoin { get; set; }

        public UserDM User { get; set; }
        public SoftwareTypeDM SoftwareType { get; set; }
    }
}
