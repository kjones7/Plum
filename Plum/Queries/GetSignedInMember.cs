using System.Security.Claims;
using MediatR;
using Plum.Models;

namespace Plum.Queries
{
    public class GetSignedInMember : IRequest<Member>
    {
        public ClaimsPrincipal User { get; }
        public int LibraryId { get; }

        public GetSignedInMember(ClaimsPrincipal user, int libraryId)
        {
            User = user;
            LibraryId = libraryId;
        }
    }
}
