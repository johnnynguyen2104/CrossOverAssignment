using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.DAL.DomainModels;

namespace CrossOverAssignment.DAL.Interfaces
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        IDbContext DbContext { get; set; }

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        TEntity FindOne(Expression<Func<TEntity, bool>> expression);

        int Create(TEntity entity);

        int Update(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> expression);
    }
}
