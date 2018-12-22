using MediatR;
using System.Collections.Generic;
using Plum.Models;

namespace Plum.Commands
{
    public class ReplacePrivilegesOfRole : IRequest
    {
        public int RoleId { get; }
        public IEnumerable<Privilege> Privileges { get; }

        public ReplacePrivilegesOfRole(int roleId, IEnumerable<Privilege> privileges)
        {
            RoleId = roleId;
            Privileges = privileges;
        }
    }
}
