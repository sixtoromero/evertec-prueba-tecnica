namespace evertec.Domain.Interface
{
    public interface IDomain<T>
    {
        Task<bool> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(int ID);
        Task<T> GetAsync(int ID);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
