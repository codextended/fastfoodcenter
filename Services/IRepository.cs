using System.Linq;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace FastfoodCenter.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entityToInsert);

        void Update(TEntity entityToUpdate);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        void Delete(TEntity entityToDelete);

        void Delete(object id);
    }
}