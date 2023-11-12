namespace AVIDI.ApiService.Data.Repository.Interfaces
{
    public interface IDataEventRepository<T>
    {
        Task<IEnumerable<T>> GetEventsAsync(int year, string month);
        Task AddAsync(T entity);
    }
}