namespace Telegram2A.Core
{
    public class AuthKeyValue
    {
        public int Id { get; set; }
        public int ForeignId { get; set; }
        public string NameOfAuth { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public User Owner { get; set; } = null!;
        public AuthKeyValue() { }
        public AuthKeyValue(string nameOfAuth, string secret)
        {
            NameOfAuth = nameOfAuth;
            Secret = secret;
        }
    }
}
