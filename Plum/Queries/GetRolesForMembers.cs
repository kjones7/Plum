using System.Collections.Generic;
using MediatR;
using Plum.Models;

namespace Plum.Queries
{
    public class GetRolesForMembers : IRequest<IDictionary<int, Role>>
    {
        public IList<int> MembershipIds { get; }

        public GetRolesForMembers(IList<int> membershipIds)
        {
            MembershipIds = membershipIds;
        }
    }
}
