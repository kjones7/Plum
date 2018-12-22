using MediatR;
using Plum.Models;

namespace Plum.Queries
{
    public class GetRoleForMember : IRequest<Role>
    {
        public int MembershipId { get; }

        public GetRoleForMember(int membershipId)
        {
            MembershipId = membershipId;
        }
    }
}
