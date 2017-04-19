﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.DAL.DomainModels;
using CrossOverAssignment.DAL.Interfaces;

namespace CrossOverAssignment.DAL.Implementations
{
    public class Repository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        public IDbContext DbContext { get; set; }

        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> expression)
        {
            var result = DbContext.Set<TKey, TEntity>().Where(expression);

            return result;
        }

        public TEntity ReadOne(Expression<Func<TEntity, bool>> expression)
        {
            var entity = DbContext.Set<TKey, TEntity>().FirstOrDefault(expression);

            return entity;
        }

        public TEntity Create(TEntity entity)
        {
            return DbContext.Set<TKey, TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            var updateEntity = ReadOne(a => a.Id.Equals(entity.Id));
            DbContext.Entry<TKey, TEntity>(updateEntity).CurrentValues.SetValues(entity);
        }

        public int Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entities = DbContext.Set<TKey, TEntity>().Where(expression);

            foreach (var entity in entities)
            {
                DbContext.Set<TKey, TEntity>().Remove(entity);
            }

            return DbContext.CommitChanges();
        }

        public int CommitChanges()
        {
            return DbContext.CommitChanges();
        }
    }
}
