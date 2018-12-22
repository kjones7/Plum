using MediatR;
using System.Collections.Generic;
using Plum.Models;

namespace Plum.Queries
{
    public class GetMembersOfLibrary : IRequest<IEnumerable<Member>>
    {
        public int LibraryId { get; }

        public GetMembersOfLibrary(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}
