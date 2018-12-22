﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Dtos;
using Plum.Extensions;
using Plum.Models;
using Plum.Queries;

namespace Plum.Pages
{
    [Authorize]
    public class LibraryModel : PageModel
    {
        private readonly IMediator _mediator;

        public LibraryModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public LibraryDto Library { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<VideoDto> Videos { get; set; }
        public Member Member { get; set; }

        [BindProperty]
        [StringLength(64, MinimumLength = 1)]
        [Display(Name = "Change Display Name")]
        [Required]
        public string NewDisplayName { get; set; }

        [BindProperty]
        [Required]
        public int MembershipId { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public int Id { get; set; }

        public async Task OnGetAsync()
        {
            await SetUpPage();
        }

        public async Task<IActionResult> OnPostDisplayNameAsync()
        {
            if (!ModelState.IsValid)
            {
                await SetUpPage();
                return Page();
            }

            await _mediator.Send(new UpdateDisplayName(MembershipId, NewDisplayName));
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteVideo(int videoId, int libraryId)
        {
            var member = await _mediator.Send(new GetSignedInMember(User, libraryId));

            if (!member.Role.Privileges.Contains(Privilege.CanRemoveAnyVideo))
            {
                return this.InsufficientPrivileges();
            }

            await _mediator.Send(new DeleteVideoFromLibrary(videoId));
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetAcceptInvitationAsync(string urlKey)
        {
            var invitation = await _mediator.Send(new GetInvitationByKey(urlKey));

            var request = new AddSignedInUserToLibrary(User, invitation.LibraryId, invitation.RoleId);
            await _mediator.Send(request);

            return RedirectToPage("/Library", new { id = invitation.LibraryId });
        }

        // TODO: Don't do it this way
        private async Task SetUpPage()
        {
            var libraryTask = _mediator.Send(new GetLibraryDtoById(Id));
            var membersTask = _mediator.Send(new GetMembersOfLibrary(Id));
            var videosTask = _mediator.Send(new GetVideosOfLibrary(Id));
            var memberTask = _mediator.Send(new GetSignedInMember(User, Id));

            Library = await libraryTask.ConfigureAwait(false);
            Members = await membersTask.ConfigureAwait(false);
            Videos = await videosTask.ConfigureAwait(false);
            Member = await memberTask.ConfigureAwait(false);
        }
    }
}