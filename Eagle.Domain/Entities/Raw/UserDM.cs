namespace Eagle.Domain.Entities.Raw
{
    public class UserDM : EntityDM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<CoinRecordDM> CoinRecords { get; set; }
        public CoinDM Coin { get; set; }
    }
}
