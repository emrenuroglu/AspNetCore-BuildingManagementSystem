namespace BuildingManagement.Application.Contracts
{
    /// <summary>
    /// Genel yazma (create, update, delete) işlemlerini yöneten generic repository arayüzü.
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public interface IWriteRepository<T> where T : class
    {
        // Ekleme İşlemleri
        /// <summary>
        /// Yeni bir entity ekler.
        /// </summary>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Birden fazla entity'yi toplu olarak ekler.
        /// </summary>
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities);

        // Güncelleme İşlemleri
        /// <summary>
        /// Mevcut bir entity'yi günceller.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Birden fazla entity'yi toplu olarak günceller.
        /// </summary>
        void UpdateRange(IEnumerable<T> entities);

        // Silme İşlemleri (Soft Delete)
        /// <summary>
        /// Entity'yi soft delete (pasif) olarak siler.
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Birden fazla entity'yi toplu olarak soft delete (pasif) olarak siler.
        /// </summary>
        void DeleteRange(IEnumerable<T> entities);

        // Kalıcı Silme İşlemleri (Hard Delete)
        /// <summary>
        /// Entity'yi kalıcı olarak (veritabanından) siler.
        /// </summary>
        void HardDelete(T entity);

        /// <summary>
        /// Birden fazla entity'yi kalıcı olarak siler.
        /// </summary>
        void HardDeleteRange(IEnumerable<T> entities);

        // Değişiklikleri Kaydetme
        /// <summary>
        /// Değişiklikleri veritabanına kaydeder.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // Transaction Desteği
        /// <summary>
        /// Transaction başlatır.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Transaction'ı commit eder.
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Transaction'ı geri alır (rollback).
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
