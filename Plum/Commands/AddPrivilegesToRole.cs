using MediatR;
using System.Collections.Generic;
using Plum.Models;

namespace Plum.Commands
{
    public class AddPrivilegesToRole : IRequest
    {
        public int RoleId { get; }
        public IEnumerable<Privilege> Privileges { get; }

        public AddPrivilegesToRole(int roleId, IEnumerable<Privilege> privileges)
        {
            RoleId = roleId;
            Privileges = privileges;
        }
    }
}
