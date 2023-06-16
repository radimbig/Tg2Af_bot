
namespace Telegram2A
{
    public class AuthKeyValue
    {
        public int Id;
        public int ForeignId;
        public string Key = null!;
        public string Value = null!;

        public AuthKeyValue() { }
        public AuthKeyValue(string key,string value)
        {
            Key = key;
            Value = value;
        }
    }
}
