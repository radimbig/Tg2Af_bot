using MediatR;

namespace Telegram2A.Manipulation.Users.Commands.AddUser
{
    public class AddUserCommand:IRequest
    {
        public string UserName { get; set;}
        public int TelegramId { get; set; }

        public AddUserCommand(string UserName, int TelegramId)
        {
            this.UserName = UserName;
            this.TelegramId = TelegramId;
        }
    }
}
