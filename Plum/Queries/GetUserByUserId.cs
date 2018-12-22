using System.Security.Claims;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetUserByUserId : IRequest<UserDto>
    {
        public int UserId { get; }

        public GetUserByUserId(int userId)
        {
            UserId = userId;
        }
    }
}
