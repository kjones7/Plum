using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetInvitationsForLibrary : IRequest<IEnumerable<InvitationDto>>
    {
        public int LibraryId { get; }

        public GetInvitationsForLibrary(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}