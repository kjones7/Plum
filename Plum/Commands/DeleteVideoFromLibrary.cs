using MediatR;

namespace Plum.Commands
{
    public class DeleteVideoFromLibrary : IRequest
    {
        public int VideoId;

        public DeleteVideoFromLibrary(int videoId)
        {
            VideoId = videoId;
        }
    }
}
