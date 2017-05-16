using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SocialNetworkSystem.Data.Models;

namespace SocialNetworkSystem.Data.Contracts
{
    public interface IApplicationDbContext
    {
        IDbSet<User> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
