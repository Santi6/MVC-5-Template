using Microsoft.AspNet.Identity.EntityFramework;
using SocialNetworkSystem.Data.Contracts;
using SocialNetworkSystem.Data.Models;

namespace SocialNetworkSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
