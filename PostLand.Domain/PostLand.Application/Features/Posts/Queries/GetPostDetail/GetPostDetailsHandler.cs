using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetail;

public class GetPostDetailsHandler : IRequestHandler<GetPostDetails, GetPostDetailVm>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostDetailsHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<GetPostDetailVm> Handle(GetPostDetails request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id, true);
        return _mapper.Map<GetPostDetailVm>(post);
    }
}
