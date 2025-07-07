using BuildingManagement.Application.Contracts;
using BuildingManagement.Persistence.Context;

namespace BuildingManagement.Persistence.Repo
{
    /// <summary>
    /// Tüm repository'lere erişimi ve transaction yönetimini sağlar.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        // Repository cache'leri
        private readonly Dictionary<Type, object> _readRepositories = new();
        private readonly Dictionary<Type, object> _writeRepositories = new();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// İstediğin entity için okuma (read) repository'sini verir.
        /// </summary>
        public IReadRepository<T> Read<T>() where T : class
        {
            if (_readRepositories.TryGetValue(typeof(T), out var repo))
                return (IReadRepository<T>)repo;

            var newRepo = new ReadRepository<T>(_context);
            _readRepositories.Add(typeof(T), newRepo);
            return newRepo;
        }

        /// <summary>
        /// İstediğin entity için yazma (write) repository'sini verir.
        /// </summary>
        public IWriteRepository<T> Write<T>() where T : class
        {
            if (_writeRepositories.TryGetValue(typeof(T), out var repo))
                return (IWriteRepository<T>)repo;

            var newRepo = new WriteRepository<T>(_context);
            _writeRepositories.Add(typeof(T), newRepo);
            return newRepo;
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

        /// <summary>
        /// Context'i kapatır ve memory leak oluşmasını engeller.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
