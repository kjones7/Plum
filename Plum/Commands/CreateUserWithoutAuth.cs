using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class CreateUserWithoutAuth : IRequest<UserDto>
    {
        public string DisplayName { get; }

        public CreateUserWithoutAuth(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
