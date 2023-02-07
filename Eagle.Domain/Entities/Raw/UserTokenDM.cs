namespace Eagle.Domain.Entities.Raw
{
    public class UserTokenDM : EntityDM
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string UserIpAddress { get; set; }
        public string LogonPlaceGuid { get; set; }

        public UserDM User { get; set; }
    }
}
