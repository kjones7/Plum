using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class CreateAnnotation : IRequest<AnnotationDto>
    {
        public int UserId { get; }
        public string Comment { get; }
        public int VideoId { get; }
        public double Timestamp { get; }

        public CreateAnnotation(int userId, string comment, int videoId, double timestamp)
        {
            UserId = userId;
            Comment = comment;
            VideoId = videoId;
            Timestamp = timestamp;
        }
    }
}
