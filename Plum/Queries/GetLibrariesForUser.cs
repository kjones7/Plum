using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetLibrariesForUser : IRequest<IEnumerable<LibraryDto>>
    {
        public int UserId { get; }

        public GetLibrariesForUser(int userId)
        {
            UserId = userId;
        }
    }
}
