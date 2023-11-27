using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contracts;
using PostLand.Domain.Models;
using PostLand.Persistence.DB;

namespace PostLand.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext postDbContext) : base(postDbContext)
        {

        }
        public async Task<IReadOnlyList<Post>> GetAllAsync(bool includeCategory)
        {
            List<Post> allPosts = new List<Post>();
            allPosts = includeCategory ? await _dbContext.Posts.Include(x => x.Category).ToListAsync() : await _dbContext.Posts.ToListAsync();
            return allPosts;
        }

        public async Task<Post> GetByIdAsync(Guid id, bool includeCategory)
        {
            Post Post = new Post();
            Post = includeCategory ? await _dbContext.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return Post;
        }
    }
}
