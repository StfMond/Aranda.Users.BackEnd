namespace Aranda.Users.BackEnd.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DefaultScheme { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessExpiration { get; set; }
        public string RefreshExpiration { get; set; }
    }
}
