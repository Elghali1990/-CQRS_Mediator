using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Commands.Delete;

public class DeletePostHandler : IRequestHandler<DeletePost, Guid>
{
    private readonly IPostRepository _postRepository;

    public DeletePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Guid> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId);
        await _postRepository.DeleteAsync(post);
        return post.Id;
    }
}
