using BlazorWebApp_Silicon.Client;
using BlazorWebApp_Silicon.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;

namespace BlazorWebApp_Silicon.Components.Account
{
    internal sealed class PersistingRevalidatingAuthenticationStateProvider : RevalidatingServerAuthenticationStateProvider
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly PersistentComponentState state;
        private readonly IdentityOptions options;
        private readonly ILogger<PersistingRevalidatingAuthenticationStateProvider> logger;

        private readonly PersistingComponentStateSubscription subscription;

        private Task<AuthenticationState>? authenticationStateTask;

        public PersistingRevalidatingAuthenticationStateProvider(
            ILoggerFactory loggerFactory,
            IServiceScopeFactory serviceScopeFactory,
            PersistentComponentState persistentComponentState,
            IOptions<IdentityOptions> optionsAccessor)
            : base(loggerFactory)
        {
            scopeFactory = serviceScopeFactory;
            state = persistentComponentState;
            options = optionsAccessor.Value;
            logger = loggerFactory.CreateLogger<PersistingRevalidatingAuthenticationStateProvider>();

            AuthenticationStateChanged += OnAuthenticationStateChanged;
            subscription = state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveWebAssembly);
        }

        protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);

        protected override async Task<bool> ValidateAuthenticationStateAsync(
            AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            try
            {
                await using var scope = scopeFactory.CreateAsyncScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                return await ValidateSecurityStampAsync(userManager, authenticationState.User);
            }
            catch (Exception ex)
            {
                // Log the exception for better debugging
                logger.LogError(ex, "Error validating authentication state");
                throw;
            }
        }

        private async Task<bool> ValidateSecurityStampAsync(UserManager<ApplicationUser> userManager, ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user is null)
            {
                return false;
            }
            else if (!userManager.SupportsUserSecurityStamp)
            {
                return true;
            }
            else
            {
                var principalStamp = principal.FindFirstValue(options.ClaimsIdentity.SecurityStampClaimType);
                var userStamp = await userManager.GetSecurityStampAsync(user);
                return principalStamp == userStamp;
            }
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            authenticationStateTask = task;
        }

        private async Task OnPersistingAsync()
        {
            try
            {
                if (authenticationStateTask is null)
                {
                    throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
                }

                var authenticationState = await authenticationStateTask;
                var principal = authenticationState.User;

                if (principal.Identity?.IsAuthenticated == true)
                {
                    var userId = principal.FindFirst(options.ClaimsIdentity.UserIdClaimType)?.Value;
                    var email = principal.FindFirst(options.ClaimsIdentity.EmailClaimType)?.Value;

                    if (userId != null && email != null)
                    {
                        state.PersistAsJson(nameof(UserInfo), new UserInfo
                        {
                            UserId = userId,
                            Email = email,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for better debugging
                logger.LogError(ex, "Error during persisting authentication state");
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                subscription.Dispose();
                AuthenticationStateChanged -= OnAuthenticationStateChanged;
            }
            base.Dispose(disposing);
        }
    }
}
