namespace PostLand.Application.Contracts
{
    public interface IAsyncRepository<Table> where Table : class
    {
        Task<Table> CreateAsync(Table table);
        Task<Table> UpdateAsync(Table table);
        Task<Table> DeleteAsync(Table table);
        Task<Table> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Table>> GetAllAsync();
    }
}
