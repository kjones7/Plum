using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetAnnotationRepliesByVideoId : IRequest<IEnumerable<ReplyDto>>
    {
        public int VideoId { get; }

        public GetAnnotationRepliesByVideoId(int videoId)
        {
            VideoId = videoId;
        }
    }
}