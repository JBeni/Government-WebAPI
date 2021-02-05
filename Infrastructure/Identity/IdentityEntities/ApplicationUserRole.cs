using Microsoft.AspNetCore.Identity;

namespace GovernmentSystem.Infrastructure.Identity.IdentityEntities
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }
}
