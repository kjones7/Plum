using MediatR;
using Plum.Models;

namespace Plum.Queries
{
    public class GetSearchResults : IRequest<SearchResults>
    {
        public int UserId { get; }
        public string Query { get; }

        public GetSearchResults(int userId, string query)
        {
            UserId = userId;
            Query = query;
        }
    }
}
