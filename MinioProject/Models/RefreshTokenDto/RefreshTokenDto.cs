namespace Models
{
    public class RefreshTokenDto
    {
        public RefreshTokenDto(string token, DateTime expiryTime)
        {
            Token = token;
            ExpiryTime = expiryTime;
        }
        
        public string Token { get; set; }
        
        public DateTime ExpiryTime { get; set; }
    }
}