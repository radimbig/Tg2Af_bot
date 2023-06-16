
namespace Telegram2A
{
    public class AuthKeyValue
    {
        public int Id;
        public int ForeignId;
        public string NameOfAuth = null!;
        public string Secret = null!;
        public User Owner = null!;
        public AuthKeyValue() { }
        public AuthKeyValue(string nameOfAuth,string secret)
        {
            NameOfAuth = nameOfAuth;
            Secret = secret;
        }
    }
}
