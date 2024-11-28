namespace TeledocTest.Core.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<Guid> AddAsync(T client);

        Task<Guid> DeleteAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<Guid> UpdateAsync(T client);
    }
}