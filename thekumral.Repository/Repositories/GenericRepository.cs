
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Repositories;

namespace thekumral.Repository.Repositories
{
    /// <summary>
    /// Veritabanı işlemleri için genel repository sınıfı.
    /// </summary>
    /// <typeparam name="T">Varlık türü</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// GenericRepository sınıfının bir örneğini oluşturur.
        /// </summary>
        /// <param name="context">Uygulama veritabanı bağlamı</param>
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Yeni bir varlık ekler.
        /// </summary>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Birden fazla varlık ekler.
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// Belirtilen koşula uyan herhangi bir varlık var mı diye kontrol eder.
        /// </summary>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        /// <summary>
        /// Tüm varlıkları getirir.
        /// </summary>
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Belirli bir varlığı kimliğine göre getirir.
        /// </summary>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Belirli bir varlığı kaldırır.
        /// </summary>
        public void Remove(T entity)
        {
            var propertyInfo = typeof(T).GetProperty("IsDeleted");
            if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
            {
                propertyInfo.SetValue(entity, true);
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Birden fazla varlığı kaldırır.
        /// </summary>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Bir varlığı günceller.
        /// </summary>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Belirtilen koşula uyan varlıkları getirir.
        /// </summary>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
