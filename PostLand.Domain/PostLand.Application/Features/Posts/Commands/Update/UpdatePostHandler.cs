using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain.Models;

namespace PostLand.Application.Features.Posts.Commands.Update;

public class UpdatePostHandler : IRequestHandler<UpdatePost,Guid>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        Post post = _mapper.Map<Post>(request);
        await _postRepository.UpdateAsync(post);
        return post.Id;
    }
}
