namespace AgendaPro.Domain.Entities.Security
{
    public class AspNetUsersRefreshToken
    {
        public int Id { get; set; }
        public Guid AspNetUsersId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
    }
}
