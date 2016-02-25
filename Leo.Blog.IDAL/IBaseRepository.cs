using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Blog.IDAL
{
    public interface IBaseRepository<T> where T:class
    {
        T AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> exp = null);
        T FindSingle(Expression<Func<T, bool>> exp);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out  int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda);
        //IQueryable<T> Filter(Expression<Func<T, bool>> exp = null);
    }
}
