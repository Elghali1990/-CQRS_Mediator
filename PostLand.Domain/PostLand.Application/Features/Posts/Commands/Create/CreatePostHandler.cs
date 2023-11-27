using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain.Models;

namespace PostLand.Application.Features.Posts.Commands.Create
{
    public class CreatePostHandler : IRequestHandler<CreatePost , Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            CreateCommandValidator validation = new();
            var result = await validation.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }
            post =await _postRepository.CreateAsync(post);
            return post.Id;
        }
    }
}
