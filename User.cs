namespace Telegram2A
{
    public class User
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string Name { get; set; } = null!;
        public List<AuthKeyValue> AuthKeyValues { get; set; } = new();
        public User() { }

        public User(int telegramId, string name)
        {

        }
    }
}
