namespace BuildingManagement.Application.Contracts
{
    /// <summary>
    /// Genel okuma (read) işlemlerini yöneten generic repository arayüzü.
    /// </summary>
    /// <typeparam name="T">Entity tipi</typeparam>
    public interface IReadRepository<T> where T : class
    {
        // Tekil Entity Sorguları
        /// <summary>
        /// Id bilgisine göre entity'yi getirir.
        /// </summary>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Belirtilen koşula uyan ilk entity'yi getirir.
        /// </summary>
        Task<T?> FindSingleAsync(Expression<Func<T, bool>> expression);

        // Çoklu Entity Sorguları
        /// <summary>
        /// Tüm entity'leri getirir.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Belirtilen koşula uyan entity'leri getirir.
        /// </summary>
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        // Varlık Kontrolü
        /// <summary>
        /// Id bilgisine sahip entity var mı kontrol eder.
        /// </summary>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Belirtilen koşula uyan entity var mı kontrol eder.
        /// </summary>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        // Sayı Hesaplama
        /// <summary>
        /// Tüm entity'lerin sayısını döner.
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Belirtilen koşula uyan entity'lerin sayısını döner.
        /// </summary>
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        // Sayfalama
        /// <summary>
        /// Sayfalama yaparak entity listesi döner.
        /// </summary>
        /// <param name="pageNumber">Sayfa numarası (1'den başlar)</param>
        /// <param name="pageSize">Sayfa başına gösterilecek kayıt sayısı</param>
        /// <param name="filter">Opsiyonel filtre koşulu</param>
        /// <param name="orderBy">Opsiyonel sıralama alanı</param>
        /// <param name="orderByDescending">Azalan (true) / artan (false) sıralama</param>
        /// <returns>İlgili sayfadaki entity'ler ve toplam kayıt sayısı</returns>
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>? orderBy = null,
            bool orderByDescending = false);

        // Seçimli Sorgular
        /// <summary>
        /// Belirtilen alanlara göre entity'leri projekte eder (select).
        /// </summary>
        /// <typeparam name="TResult">Dönüş tipi</typeparam>
        /// <param name="selector">Dönen property'leri belirler</param>
        /// <param name="filter">Opsiyonel filtre koşulu</param>
        /// <returns>Seçilen alanların listesi</returns>
        Task<List<TResult>> SelectAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Func<IQueryable<T>, IQueryable<T>>? includeFunc = null);
    }
}
