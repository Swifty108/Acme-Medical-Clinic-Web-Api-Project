using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apartments.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        public Task<TEntity> GetByID(object id);

        public Task Insert(TEntity entity);

        public void Update(TEntity entityToUpdate);

        public Task Delete(object id);

        public void Delete(TEntity entityToDelete);
    }
}