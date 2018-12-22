using MediatR;
using Plum.Dtos;
namespace Plum.Queries
{
    public class GetLibraryDtoById : IRequest<LibraryDto>
    {
        public int Id { get; }

        public GetLibraryDtoById(int id)
        {
            Id = id;
        }
    }
}
