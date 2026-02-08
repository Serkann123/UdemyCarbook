namespace UdemyCarbook.WebUI.Models
{
    public class JwtTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
