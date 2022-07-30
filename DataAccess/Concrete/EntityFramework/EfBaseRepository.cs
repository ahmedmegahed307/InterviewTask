using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class ,new()
    {

        private readonly ProjectContext _context;
        public EfBaseRepository(ProjectContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            var addedEntity = _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            var updatedEntity = _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();

        }


        public void Delete(TEntity entity)
        {
            var deleteedEntity = _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().FirstOrDefault(filter);

        }



        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);
        }

        public IEnumerable<TEntity> GetAll2(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }
    }
}
