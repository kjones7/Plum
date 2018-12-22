using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Plum.Dtos;
using Plum.Queries;
using Microsoft.AspNetCore.Mvc;
using Plum.Models;
using Plum.Extensions;
using Plum.Commands;

namespace Plum.Pages.Libraries
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int LibraryId { get; set; }

        public IDictionary<LibraryDto, Member> Libraries { get; set; }

        public async Task OnGetAsync()
        {
            var userDto = await _mediator.Send(new GetSignedInUserDto(User));
            var libraries = await _mediator.Send(new GetLibrariesForUser(userDto.Id));

            Libraries = new Dictionary<LibraryDto, Member>();

            foreach (var library in libraries)
            {
                var member = await _mediator.Send(new GetSignedInMember(User, library.Id));
                Libraries.Add(library, member);
            }
        }

        public async Task<IActionResult> OnPostDeleteLibrary(int libraryId)
        {
            var member = await _mediator.Send(new GetSignedInMember(User, LibraryId));

            if (!member.Role.Privileges.Contains(Privilege.CanRemoveLibrary))
            {
                return this.InsufficientPrivileges();
            }

            await _mediator.Send(new DeleteLibrary(libraryId));
            return RedirectToPage();
        }
    }
}