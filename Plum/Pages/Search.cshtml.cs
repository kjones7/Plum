using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Plum.Models;
using Plum.Queries;

namespace Plum.Pages
{
    [Authorize]
    public class SearchModel : PageModel
    {
        private readonly IMediator _mediator;

        public SearchModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string Query { get; set; }

        public SearchResults SearchResults { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _mediator.Send(new GetSignedInUserDto(User));
            SearchResults =  await _mediator.Send(new GetSearchResults(user.Id, Query));
            return Page();
        }
    }
}