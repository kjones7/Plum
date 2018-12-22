using MediatR;
using Plum.Dtos;

namespace Plum.Commands
{
    public class CreateLibrary : IRequest
    {
        public int UserId { get; }
        public string Title { get; }
        public string Description { get; }


        public CreateLibrary(int userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }
    }
}
