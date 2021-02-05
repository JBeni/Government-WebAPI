using Microsoft.AspNetCore.Identity;

namespace GovernmentSystem.Infrastructure.Identity.IdentityEntities
{
    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}
