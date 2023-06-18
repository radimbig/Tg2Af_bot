using Telegram.Bot;
using Telegram.Bot.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Telegram2A.Manipulation.Users.Queries.GetUser;

namespace Telegram2A.Core
{
    public class TgBot
    {
        private readonly TelegramBotClient client;
        private readonly IMediator mediator = new ServiceCollection().AddMediatR((args) => { args.RegisterServicesFromAssembly(typeof(Program).Assembly); }).BuildServiceProvider().GetRequiredService<IMediator>();

        public TgBot()
        {
            string TgToken = Env.GetToken();
            client = new TelegramBotClient(TgToken);
            
        }
        public async void Run()
        {
            var user = await mediator.Send(new GetUserQuery(123123));
            client.StartReceiving(updateHandler: UpdateHandler, ErrorHandler);
        }
        public Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task ErrorHandler(ITelegramBotClient client, Exception error, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
