using MediatR;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetail;

public class GetPostDetails:IRequest<GetPostDetailVm>
{
    public Guid Id { get; set; }
}
