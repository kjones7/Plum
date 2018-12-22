using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetVideosOfLibrary: IRequest<IEnumerable<VideoDto>>
    {
        public int LibraryId { get; }

        public GetVideosOfLibrary(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}
