using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class CreateAnnotationReply : IRequest<ReplyDto>
    {
        public int UserId { get; }
        public int AnnotationId { get; }
        public string Text { get; }

        public CreateAnnotationReply(int userId, int annotationId, string text)
        {
            UserId = userId;
            AnnotationId = annotationId;
            Text = text;
        }
    }
}
