using MediatR;
using Plum.Dtos;
namespace Plum.Queries
{
    public class GetInvitationByKey : IRequest<InvitationDto>
    {
        public string Key { get; }

        public GetInvitationByKey(string key)
        {
            Key = key;
        }
    }
}
