using MediatR;
using Telegram2A.Core;
using Telegram2A.Database;

namespace Telegram2A.Manipulation.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            using(var ctx = new MyDbContext())
            {
                await ctx.Users.AddAsync(new User(request.TelegramId, request.UserName), cancellationToken);
                await ctx.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
