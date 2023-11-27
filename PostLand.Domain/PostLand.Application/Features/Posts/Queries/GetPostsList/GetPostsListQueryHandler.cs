using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Queries.GetPostsList;

public class GetPostsListQueryHandler : IRequestHandler<GetPosts, List<PostVm>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostsListQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostVm>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
        var allPosts = await _postRepository.GetAllAsync(true);
        return _mapper.Map<List<PostVm>>(allPosts);
    }
}
