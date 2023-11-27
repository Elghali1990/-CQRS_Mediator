using PostLand.Domain.Models;

namespace PostLand.Application.Features.Posts.Queries.GetPostsList;
public class PostVm
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public CategoryDto CategoryDto { get; set; }
}
