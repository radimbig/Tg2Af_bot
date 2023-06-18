using MediatR;
using Telegram2A.Core;

namespace Telegram2A.Manipulation.AuthDict.Commands
{
    public class AddAuthPairCommand:IRequest
    {
        public int OwnerId;
        public string NameOfAuth;
        public string Secret;

        public AddAuthPairCommand(int ownerId, string nameOfAuth, string secret)
        {
            OwnerId = ownerId;
            NameOfAuth = nameOfAuth;
            Secret = secret;
        }
        public AddAuthPairCommand(User user, string nameOfAuth, string secret)
        {
            OwnerId= user.Id;
            NameOfAuth = nameOfAuth;
            Secret = secret;
        }
    }
}
