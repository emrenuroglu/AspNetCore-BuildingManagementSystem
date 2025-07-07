using BuildingManagement.Application.Contracts;
using BuildingManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BuildingManagement.Persistence.Repo
{
    /// <summary>
    /// Generic okuma işlemleri için repository implementasyonu.
    /// Sadece veritabanından veri okuma işlemleri için kullanılır.
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// DbContext üzerinden ilgili entity tipi için DbSet atanır.
        /// </summary>
        public ReadRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Veritabanındaki tüm kayıtların toplam sayısını getirir.
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        /// <summary>
        /// Belirli bir şarta uyan kayıtların toplam sayısını getirir.
        /// </summary>
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        /// <summary>
        /// Belirli bir Id'ye sahip kayıt var mı kontrol eder.
        /// Entity'de 'Id' property'si olmak zorundadır.
        /// </summary>
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.AnyAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        /// <summary>
        /// Belirli bir şarta uyan kayıt var mı kontrol eder.
        /// </summary>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        /// <summary>
        /// Belirli bir şarta uyan tüm kayıtları getirir.
        /// </summary>
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet
                .AsNoTracking() // Sadece okuma için, context'e eklenmez.
                .Where(expression)
                .ToListAsync();
        }

        /// <summary>
        /// Belirli bir şarta uyan ilk kaydı getirir. Yoksa null döner.
        /// </summary>
        public async Task<T?> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(expression)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Tüm kayıtları getirir.
        /// </summary>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Belirli bir Id'ye sahip kaydı getirir. Yoksa null döner.
        /// Entity'de 'Id' property'si olmak zorundadır.
        /// </summary>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        /// <summary>
        /// Sayfalama, filtreleme ve sıralama desteğiyle birlikte kayıtları getirir.
        /// </summary>
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>? orderBy = null,
            bool orderByDescending = false)
        {
            var query = _dbSet.AsNoTracking();

            // Filtre uygula
            if (filter != null)
                query = query.Where(filter);

            // Toplam kayıt sayısını al
            var totalCount = await query.CountAsync();

            // Sıralama uygula
            if (orderBy != null)
            {
                query = orderByDescending
                    ? query.OrderByDescending(orderBy)
                    : query.OrderBy(orderBy);
            }

            // Sayfalama uygula ve sonucu döndür
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// Belirli property'leri seçerek liste döner.
        /// </summary>
        public async Task<List<TResult>> SelectAsync<TResult>(
           Expression<Func<T, TResult>> selector,
           Func<IQueryable<T>, IQueryable<T>>? includeFunc = null)
        {
            var query = _dbSet.AsNoTracking();

            // Include'ları uygula
            if (includeFunc != null)
                query = includeFunc(query);

            return await query
                .Select(selector)
                .ToListAsync();
        }
    }
}
