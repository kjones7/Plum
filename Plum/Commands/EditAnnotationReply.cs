using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class EditAnnotationReply : IRequest
    {
        public int UserId { get; }
        public int ReplyId { get; }
        public string Text { get; }

        public EditAnnotationReply(int userId, int replyId, string text)
        {
            UserId = userId;
            ReplyId = replyId;
            Text = text;
        }
    }
}
