using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PostLand.Application.Contracts;
using PostLand.Persistence.DB;
using System.Xml.Linq;

namespace PostLand.Persistence.Repositories
{
    public class BaseRepository<Table> : IAsyncRepository<Table> where Table : class
    {
        protected readonly PostDbContext _dbContext;

        public BaseRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Table> CreateAsync(Table table)
        {
            await _dbContext.Set<Table>().AddAsync(table);
            await _dbContext.SaveChangesAsync();
            return table;
        }

        public async Task<Table> DeleteAsync(Table table)
        {
            _dbContext.Set<Table>().Remove(table);
            await _dbContext.SaveChangesAsync();
            return table;
        }

        public async Task<IReadOnlyList<Table>> GetAllAsync()
        {
            return await _dbContext.Set<Table>().ToListAsync();
        }

        public async Task<Table> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Table>().FindAsync(id);
        }

        public async Task<Table> UpdateAsync(Table table)
        {
            _dbContext.Entry(table).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return table;
        }
    }
}
