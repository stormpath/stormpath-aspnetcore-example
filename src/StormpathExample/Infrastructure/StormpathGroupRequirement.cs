using Microsoft.AspNetCore.Authorization;

namespace StormpathExample.Infrastructure
{
    public class StormpathGroupRequirement : IAuthorizationRequirement
    {
        public StormpathGroupRequirement(string groupName)
        {
            this.GroupName = groupName;
        }

        public string GroupName { get; }
    }
}
