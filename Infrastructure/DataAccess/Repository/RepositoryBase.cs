using NPoco;
using System;
using System.Collections.Generic;
using CanbulutHukuk.Infrastructure.DataAccess.Models;

namespace CanbulutHukuk.Infrastructure.DataAccess.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity:ModelBase
    {
        protected IDatabase _context;
        public RepositoryBase(IDatabase context)
        {
            _context = context;
        }
        public virtual TEntity FindById(object id)
        {
            return _context.SingleOrDefaultById<TEntity>(id);
        }

        public virtual T FindById<T>(object id)
        {
            return _context.SingleOrDefaultById<T>(id);
        }

        public virtual TEntity FindBySql(string sql)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SingleOrDefault<TEntity>(sql);
        }

        public virtual T FindBySql<T>(string sql)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SingleOrDefault<T>(sql);
        }

        public virtual Int64 ExecuteScalar(string sql)
        {
            return _context.SingleOrDefault<Int64>(sql);
        }

        public List<object> ExecuteSp(string sql, params object[] args)
        {
            return _context.Fetch<object>(sql, args);
        }

        public void ExecuteSpNonQuery(string sql, params object[] args)
        {
            _context.Execute(sql, args);
        }

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            _context.Execute(sql, args);
        }

        public virtual TEntity FindBySql(string sql, params object[] args)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SingleOrDefault<TEntity>(sql, args);
        }

        public virtual T FindBySql<T>(string sql, params object[] args)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SingleOrDefault<T>(sql, args);
        }

        public virtual List<TEntity> ListBySql(string sql)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.Fetch<TEntity>(sql);
        }

        public virtual List<TEntity> SkipTake(long skip, long take, string sql, params object[] args)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SkipTake<TEntity>(skip, take, sql, args);
        }

        public virtual List<TEntity> SkipTake(long skip, long take, string sql)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.SkipTake<TEntity>(skip, take, sql);
        }

        public virtual List<T> ListBySql<T>(string sql)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.Fetch<T>(sql);
        }

        public virtual List<TEntity> ListBySql(string sql, params object[] args)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.Fetch<TEntity>(sql, args);
        }

        public virtual List<T> ListBySql<T>(string sql, params object[] args)
        {
            _context.OneTimeCommandTimeout = 60000;
            return _context.Fetch<T>(sql, args);
        }
         
        public virtual object Insert(TEntity entity)
        {
            return _context.Insert(entity);
        }
        public virtual int Update(TEntity entity)
        {
            return _context.Update(entity);
        }

        public virtual object Insert<T>(T entity)
        {
            return _context.Insert(entity);
        }
        public virtual int Update<T>(T entity)
        {
            return _context.Update(entity);
        }

        public virtual int Delete(object id)
        {
            return _context.Delete(id);
        }
    }

    public interface IRepository<TEntity> where TEntity : ModelBase
    {
        TEntity FindById(object id);
        TEntity FindBySql(string sql);
        object Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(object id);
    }
}