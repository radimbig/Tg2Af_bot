namespace Telegram2A.Core
{
    public class User
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AuthKeyValue> AuthKeyValues { get; set; } = new List<AuthKeyValue>();
        public User() { }

        public User(int telegramId, string name)
        {
            TelegramId = telegramId;
            Name = name;
        }
    }
}
