using FAP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kwisspel.Repository.Generic
{
    public class GenericRepository<TEntity>
        where TEntity : class
    {
        protected FAPEntities       Context { get; }
        protected DbSet<TEntity>    DbSet   { get; }

        public GenericRepository(FAPEntities context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        /// <summary>
        /// Query through a dataset that was retrieved from an Entity Framework context.
        /// </summary>
        /// <param name="filter">A lambda expression used to filter data from the dbset</param>
        /// <param name="orderBy">A delegate or lambda used to order data that was queried from the dbset</param>
        /// <param name="additionalIncludes">Additional entity includes</param>
        /// <returns>A result set containing the queried data</returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>                         filter = null, //Expression<...> to convert lambda into EF query
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>   orderBy = null,
            params string[]                                         additionalIncludes)
        {
            IQueryable<TEntity> query = DbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            foreach (var include in additionalIncludes)
            {
                query = query.Include(include);
            }

            return orderBy?.Invoke(query).ToList() ?? query.ToList();
        }
        
        public virtual TEntity GetByPrimaryKey(object key)
        {
            return DbSet.Find(key);
        }
        
        public virtual TEntity GetByPrimaryKey(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Attempt to insert null value");
            }

            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(object key)
        {
            var entityToDelete = GetByPrimaryKey(key);

            Delete(entityToDelete);
            Context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Attempt to delete a null value");
            }

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Attempt to update a null value");
            }

            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
