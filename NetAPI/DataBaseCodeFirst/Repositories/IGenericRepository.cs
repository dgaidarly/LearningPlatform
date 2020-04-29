using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VieJSLearning.Dal.Entities;

namespace VieJSLearning.Dal.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void UpdateInAttachedState(TEntity oldEntity, TEntity newEntity);
        bool EntityExists(Expression<Func<TEntity, bool>> filter);
    }
}