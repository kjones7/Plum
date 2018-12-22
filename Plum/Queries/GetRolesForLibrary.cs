using MediatR;
using System.Collections.Generic;
using Plum.Models;

namespace Plum.Queries
{
    public class GetRolesForLibrary : IRequest<IEnumerable<Role>>
    {
        public int LibraryId { get; }

        public GetRolesForLibrary(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}
