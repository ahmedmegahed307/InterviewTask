using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : class 
        ,new()
    {
        // I added all these methods Incase we need to use another translator, and I used some of it.
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetAll2(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);

    }
}
