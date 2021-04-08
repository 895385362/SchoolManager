using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace S1mple_SchoolManager.Entity
{
    public class GenericRepository
    {
        public DbContext context;

        public GenericRepository()
        {
            context = new DbContext(ConfigurationManager.ConnectionStrings["SchoolManager"].ConnectionString);
        }

        public GenericRepository(DbContext db)
        {
            context = db;
        }

        public int FlushToSqlStr(string SqlStr)
        {
            return context.Database.ExecuteSqlCommand(SqlStr);
        }

        #region 通用方法
        /// <summary>
        /// 创建
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Create<T>(T t) where T : class, new()
        {
            context.Set<T>().Add(t);
        }
        public void Create<T>(List<T> t) where T : class, new()
        {
            context.Set<T>().AddRange(t);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Update<T>(T t) where T : class
        {
            context.Set<T>().Attach(t);
            context.Entry<T>(t).State = EntityState.Modified;

            // return context.SaveChanges() > 0;
        }
        public void Update<T>(List<T> t) where T : class
        {
            foreach (var item in t)
            {
                context.Set<T>().Attach(item);
                context.Entry<T>(item).State = EntityState.Modified;
            }
            // return context.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(T t) where T : class, new()
        {
            context.Set<T>().Remove(t);
        }

        /// <summary>
        /// 根据实体类集合删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(List<T> t) where T : class, new()
        {
            context.Set<T>().RemoveRange(t);
        }

        /// <summary>
        /// 根据id获取实体类集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntity<T>(Guid id) where T : class, new()
        {
            var entity = context.Set<T>().Find(id);
            return entity;
        }


        public T GetEntity<T>(Expression<Func<T, bool>> bo) where T : class, new()
        {
            return context.Set<T>().FirstOrDefault(bo);
        }

        public List<T> SelectToSqlStr<T>(string sqlStr) where T : new()
        {
            return context.Database.SqlQuery<T>(sqlStr).ToList();
        }
        /// <summary>
        /// 常用方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetEntities<T>() where T : class, new()
        {
            var objs = context.Set<T>();
            return objs;
        }

        public IQueryable<T> GetEntities<T>(Expression<Func<T, bool>> bo) where T : class, new()
        {
            var objs = context.Set<T>().Where(bo);
            return objs;
        }
        public List<T> SelectSql<T>(string sql) where T : new()
        {
            List<T> objs = context.Database.SqlQuery<T>(sql).ToList();

            return objs;
        }

        public List<T> GetListByWhere<T>(Expression<Func<T, bool>> bo) where T : class, new()
        {
            List<T> objs = new List<T>();
            if (bo != null)
                objs = context.Set<T>().Where(bo).ToList();
            else
                objs = context.Set<T>().ToList();
            return objs;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">每页条数</param>
        /// <param name="orderBy"></param>
        /// <param name="IsDESC"></param>
        /// <returns></returns>
        public Page<T> GetPages<T>(int pageindex, int pagesize, Func<IQueryable<T>, IQueryable<T>> option = null) where T : class, new()
        {
            var dataset = context.Set<T>();

            IQueryable<T> objs;

            if (option != null)
            {
                objs = option(dataset);
            }
            else
            {
                objs = dataset.Where(o => 1 == 1);
            }

            int count = objs.Count();

            IList<T> pagedata = objs.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();

            Page<T> page = new Page<T>(pagedata, pageindex, pagesize, count);

            return page;
        }

        public Page<T> GetPages<T>(int pageindex, int pagesize, Expression<Func<T, bool>> bo, Func<IQueryable<T>, IQueryable<T>> option = null) where T : class, new()
        {
            var objs = context.Set<T>().Where(bo);

            if (option != null)
            {
                objs = option(objs);
            }

            int count = objs.Count();

            IList<T> pagedata = objs.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();

            Page<T> page = new Page<T>(pagedata, pageindex, pagesize, count);

            return page;

        }


        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        #endregion

        #region 附加方法
       
        #endregion

    }
}
