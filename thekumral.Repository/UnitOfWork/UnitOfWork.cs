using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.UnitOfWork;

namespace thekumral.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// UnitOfWork sınıfının bir örneğini oluşturur.
        /// </summary>
        /// <param name="context">Uygulama veritabanı bağlamı</param>
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Veritabanındaki tüm değişiklikleri kaydeder.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Asenkron olarak veritabanındaki tüm değişiklikleri kaydeder.
        /// </summary>
        /// <returns>Asenkron işlem</returns>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
