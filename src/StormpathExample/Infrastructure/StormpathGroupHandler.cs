using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Stormpath.SDK;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using Stormpath.SDK.Error;
using Stormpath.SDK.Logging;

namespace StormpathExample.Infrastructure
{
    public class StormpathGroupHandler : AuthorizationHandler<StormpathGroupRequirement>
    {
        private readonly IClient _client;
        private readonly ILogger _logger;

        public StormpathGroupHandler(IClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, StormpathGroupRequirement requirement)
        {
            var userHasNameIdentifier = context.User?.HasClaim(c => c.Type == ClaimTypes.NameIdentifier) ?? false;
            if (!userHasNameIdentifier)
            {
                return;
            }

            var stormpathHref = string.Empty;
            stormpathHref = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(stormpathHref))
            {
                return;
            }

            IAccount account;
            try
            {
                account = await _client.GetAccountAsync(stormpathHref);
            }
            catch (ResourceException rex)
            {
                _logger.Info($"Error looking up '{stormpathHref}': '{rex.DeveloperMessage}'", source: nameof(StormpathGroupHandler));
                return;
            }

            var containsGroup = await account.GetGroups().Where(g => g.Name == requirement.GroupName).AnyAsync();
            if (containsGroup)
            {
                context.Succeed(requirement);
            }
        }
    }
}
