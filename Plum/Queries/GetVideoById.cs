using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetVideoById : IRequest<VideoDto>
    {
        public int Id { get; }

        public GetVideoById(int id)
        {
            Id = id;
        }
    }
}