using MediatR;

namespace PostLand.Application.Features.Posts.Commands.Create;

public class CreatePost:IRequest<Guid>
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}
