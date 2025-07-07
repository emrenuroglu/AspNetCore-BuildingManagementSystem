using BuildingManagement.Application.Contracts;
using BuildingManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Persistence.Repo
{
    /// <summary>
    /// Generic yazma işlemleri için repository implementasyonu.
    /// Create, Update, Delete işlemlerini kapsar.
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Yeni bir entity ekler.
        /// </summary>
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Birden fazla entity'yi toplu olarak ekler.
        /// </summary>
        public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        /// <summary>
        /// Mevcut bir entity'yi günceller.
        /// </summary>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Birden fazla entity'yi günceller.
        /// </summary>
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        /// <summary>
        /// Bir entity'yi siler (veritabanından kaldırır).
        /// </summary>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Birden fazla entity'yi siler (veritabanından kaldırır).
        /// </summary>
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Kalıcı (hard) delete işlemi. Normal Delete gibi çalışır.
        /// Ayrı bırakılmış ama aynı Remove kullanılır.
        /// </summary>
        public void HardDelete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Kalıcı (hard) delete işlemi. Normal Delete gibi çalışır.
        /// </summary>
        public void HardDeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Yapılan değişiklikleri veritabanına kaydeder.
        /// </summary>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Transaction başlatır.
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Transaction'ı commit eder.
        /// </summary>
        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        /// <summary>
        /// Transaction'ı geri alır (rollback).
        /// </summary>
        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
