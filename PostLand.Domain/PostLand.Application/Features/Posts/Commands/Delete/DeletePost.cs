using MediatR;

namespace PostLand.Application.Features.Posts.Commands.Delete;

public class DeletePost:IRequest<Guid>
{
    public Guid PostId { get; set; }
}
