﻿using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Extensions;

namespace Plum.Pages.Authentication
{
    public class SignInModel : PageModel
    {
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IMediator _mediator;

        public SignInModel(IAuthenticationSchemeProvider schemeProvider, IMediator mediator)
        {
            _schemeProvider = schemeProvider;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [BindProperty]
        public string Provider { get; set; }

        public IEnumerable<AuthenticationScheme> AuthenticationSchemes { get; set; }

        public async Task OnGetAsync()
        {
            AuthenticationSchemes = await GetExternalProvidersAsync().ConfigureAwait(false);
        }

        public async Task<IActionResult> OnGetGoogleSignInAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }

            await _mediator.Send(new EnsureUserIsPersisted(User));

            return Redirect(ReturnUrl ?? "/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Provider))
            {
                return BadRequest();
            }

            if (await IsProviderSupportedAsync(Provider).ConfigureAwait(false))
            {
                return BadRequest();
            }

            var redirectUrl = Url.Page("/Authentication/SignIn", new { ReturnUrl, Handler = "GoogleSignIn" });

            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

            return Challenge(properties, Provider);
        }

        private async Task<IEnumerable<AuthenticationScheme>> GetExternalProvidersAsync()
        {
            var schemes = await _schemeProvider.GetAllSchemesAsync().ConfigureAwait(false);

            return schemes.Where(s => !string.IsNullOrEmpty(s.DisplayName));
        }

        private async Task<bool> IsProviderSupportedAsync(string provider)
        {
            var schemes = await GetExternalProvidersAsync().ConfigureAwait(false);

            return !schemes.Any(s => s.Name.EqualsIgnoreCase(provider));
        }
    }
}