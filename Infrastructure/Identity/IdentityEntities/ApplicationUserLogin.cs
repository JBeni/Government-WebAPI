using Microsoft.AspNetCore.Identity;

namespace GovernmentSystem.Infrastructure.Identity.IdentityEntities
{
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}
