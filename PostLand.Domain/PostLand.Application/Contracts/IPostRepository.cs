using PostLand.Domain.Models;

namespace PostLand.Application.Contracts
{
    public interface IPostRepository:IAsyncRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetAllAsync(bool includeCategory);
        Task<Post> GetByIdAsync(Guid id,bool includeCategory);
    }
}
