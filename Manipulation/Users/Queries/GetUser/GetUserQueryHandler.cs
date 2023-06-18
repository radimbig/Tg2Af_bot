using MediatR;
using System.Data.Entity;
using Telegram2A.Core;
using Telegram2A.Database;

namespace Telegram2A.Manipulation.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = new MyDbContext())
            {
                var user = ctx.Users.FirstOrDefault(x=>x.TelegramId == request.TelegramId);
                if(user == null)
                {
                    throw new Exception($"No user found with id {request.TelegramId}");
                }
                ctx.Entry(user)
                    .Collection(u => u.AuthKeyValues)
                    .Load();
                return Task.FromResult(user);
            }
            
        }
    }
}
