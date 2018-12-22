using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class DeleteAnnotation : IRequest
    {
        public int UserId { get; }
        public int AnnotationId { get; }

        public DeleteAnnotation(int userId, int annotationId)
        {
            UserId = userId;
            AnnotationId = annotationId;
        }
    }
}
