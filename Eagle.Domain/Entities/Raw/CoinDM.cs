namespace Eagle.Domain.Entities.Raw
{
    public class CoinDM : EntityDM
    {
        public int UserId { get; set; }
        public int Total { get; set; }


        public UserDM User { get; set; }
    }
}
