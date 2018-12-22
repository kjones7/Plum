using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class DeleteAnnotationReply : IRequest
    {
        public int UserId { get; }
        public int ReplyId { get; }

        public DeleteAnnotationReply(int userId, int replyId)
        {
            UserId = userId;
            ReplyId = replyId;
        }
    }
}
