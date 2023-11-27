using MediatR;

namespace PostLand.Application.Features.Posts.Commands.Update;

public class UpdatePost:IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}
