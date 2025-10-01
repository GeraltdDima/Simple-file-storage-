namespace Models
{
    public class AccessTokenDto
    {
        public AccessTokenDto(string token, DateTime expireTime)
        {
            Token = token;
            ExpiryTime = expireTime;
        }
        
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}