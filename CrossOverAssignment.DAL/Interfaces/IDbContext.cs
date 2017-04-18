using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.DAL.DomainModels;

namespace CrossOverAssignment.DAL.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TKey, TEntity>() where TEntity : BaseEntity<TKey> where TKey : struct;

        DbEntityEntry<TEntity> Entry<TKey, TEntity>(TEntity entity) where TEntity : BaseEntity<TKey> where TKey : struct;
    }
}
