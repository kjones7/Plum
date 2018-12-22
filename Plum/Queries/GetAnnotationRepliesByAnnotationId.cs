using System.Collections.Generic;
using MediatR;
using Plum.Dtos;

namespace Plum.Queries
{
    public class GetAnnotationRepliesByAnnotationId : IRequest<IEnumerable<ReplyDto>>
    {
        public int AnnotationId { get; }

        public GetAnnotationRepliesByAnnotationId(int annotationId)
        {
            AnnotationId = annotationId;
        }
    }
}