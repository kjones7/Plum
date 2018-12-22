using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class CreateVideo : IRequest
    {
        public int UserId { get; }
        public int LibraryId { get; }
        public string Title { get; }
        public string Link { get; }
        public string Description { get; }


        public CreateVideo(int userId, int libraryId, string title, string link, string description)
        {
            UserId = userId;
            LibraryId = libraryId;
            Title = title;
            Link = link;
            Description = description;
        }
    }
}