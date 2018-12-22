using MediatR;

namespace Plum.Commands
{
    public class DeleteMemberOfLibrary : IRequest
    {
        public int MembershipId;

        public DeleteMemberOfLibrary(int membershipId)
        {
            MembershipId = membershipId;
        }
    }
}
