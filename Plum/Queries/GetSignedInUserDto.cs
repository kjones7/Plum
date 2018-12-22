using System.Security.Claims;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetSignedInUserDto : IRequest<UserDto>
    {
        public ClaimsPrincipal User { get; }

        public GetSignedInUserDto(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
