using MediatR;

namespace PostLand.Application.Features.Posts.Queries.GetPostsList;

public class GetPosts:IRequest<List<PostVm>>
{
}
