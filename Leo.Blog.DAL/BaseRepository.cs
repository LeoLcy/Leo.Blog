using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Leo.Blog.IDAL;
using Leo.Blog.Model;

namespace Leo.Blog.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected BlogEntities BlogDb = new BlogEntities();

        public T AddEntity(T entity)
        {
            //EF5.0
            BlogDb.Entry<T>(entity).State = EntityState.Added;
            BlogDb.SaveChanges();
            return entity;
        }

        public bool UpdateEntity(T entity)
        {
            BlogDb.Set<T>().Attach(entity);
            BlogDb.Entry<T>(entity).State = EntityState.Modified;
            return BlogDb.SaveChanges() > 0;
        }

        //实现对数据库的删除功能
        public bool DeleteEntity(T entity)
        {
            BlogDb.Set<T>().Attach(entity);
            BlogDb.Entry<T>(entity).State = EntityState.Deleted;
            return BlogDb.SaveChanges() > 0;
        }
        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }
        /// <summary>
        /// 查找单个
        /// </summary>
        public T FindSingle(Expression<Func<T, bool>> exp)
        {
            return BlogDb.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">如何排序，根据倒叙还是升序</param>
        /// <param name="orderByLambda">根据那个字段进行排序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out  int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda)
        {
            var temp = Filter(whereLambda);
            total = temp.Count(); //得到总的条数
            //排序,获取当前页的数据
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<T>(pageSize).AsQueryable(); //取出多少条
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<T>(pageSize).AsQueryable(); //取出多少条
            }
            return temp.AsQueryable();
        }
        private IQueryable<T> Filter(Expression<Func<T, bool>> exp=null)
        {
            var dbSet = BlogDb.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }
    }
}
