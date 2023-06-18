using MediatR;
using Telegram2A.Core;

namespace Telegram2A.Manipulation.Users.Queries.GetUser
{
    public class GetUserQuery:IRequest<User>
    {
        public int TelegramId;
        public GetUserQuery(int telegramID) 
        {
            TelegramId = telegramID;
        }
    }
}
