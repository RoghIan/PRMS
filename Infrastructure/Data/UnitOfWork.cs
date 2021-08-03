using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositories;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Complete(string userId = null)
        {
            //return await _context.SaveChangesAsync();
            return await _context.SaveChangesAsync(userId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            _repositories ??= new Hashtable();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (IGenericRepository<TEntity>) _repositories[type];
            
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(type, repositoryInstance);

            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}