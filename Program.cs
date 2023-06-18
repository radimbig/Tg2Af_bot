using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using System.Text.Json;
using Telegram2A.Core;
using Telegram2A.Database;
using Telegram2A.Manipulation.Users.Queries.GetUser;

namespace Telegram2A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bot = new TgBot();
            bot.Run();
            Console.ReadLine();
        }


    }
}