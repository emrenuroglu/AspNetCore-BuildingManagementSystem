namespace BuildingManagement.Application.Contracts
{
    /// <summary>
    /// Unit of Work deseni için genel arayüz.
    /// Repository erişimi ve transaction yönetimini sağlar.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Repository Erişimi

        /// <summary>
        /// Okuma (read) işlemleri için generic repository erişimi sağlar.
        /// </summary>
        /// <typeparam name="T">Entity tipi</typeparam>
        IReadRepository<T> Read<T>() where T : class;

        /// <summary>
        /// Yazma (write) işlemleri için generic repository erişimi sağlar.
        /// </summary>
        /// <typeparam name="T">Entity tipi</typeparam>
        IWriteRepository<T> Write<T>() where T : class;

        // Transaction Yönetimi

        /// <summary>
        /// Veritabanına yapılan değişiklikleri kaydeder.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Transaction başlatır.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Transaction'ı onaylar (commit eder).
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Transaction'ı geri alır (rollback).
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
