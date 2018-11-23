using FAP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Repository.Generic
{
    public class MasterRepository : IDisposable
    {
        private readonly FAPEntities    _context;
        private HashSet<object>         _repositories;

        public bool IsDisposed { get; private set; } = false;

        public MasterRepository()
        {
            _context = new FAPEntities();
            _repositories = new HashSet<object>();
        }

        public GenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Master repository was disposed");
            }
            
            var repository = _repositories
                .FirstOrDefault(o => o.GetType() == typeof(GenericRepository<TEntity>));

            if (repository == null)
            {
                repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(repository);
            }

            return (GenericRepository<TEntity>) repository;
        }

        public void Save()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Master repository was disposed");
            }

            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            if (!IsDisposed)
            {
                _context.Dispose();
                _repositories = null;
                GC.SuppressFinalize(this);
            }

            IsDisposed = true;
        }
    }
}
