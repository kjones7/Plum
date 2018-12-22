using MediatR;
using System.Collections.Generic;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetLibrariesCreatedByUserId : IRequest<IEnumerable<LibraryDto>>
    {
        public int UserId { get; }

        public GetLibrariesCreatedByUserId(int userId)
        {
            UserId = userId;
        }
    }
}
