using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetAnnotationsByVideoId : IRequest<IEnumerable<AnnotationDto>>
    {
        public int VideoId { get; }

        public GetAnnotationsByVideoId(int videoId)
        {
            VideoId = videoId;
        }
    }
}