using AutoMapper;
using PostLand.Application.Features.Posts.Commands.Create;
using PostLand.Application.Features.Posts.Queries.GetPostDetail;
using PostLand.Application.Features.Posts.Queries.GetPostsList;
using PostLand.Domain.Models;

namespace PostLand.Application.Profiles;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post,PostVm>().ReverseMap();
        CreateMap<Post, GetPostDetailVm>().ReverseMap();
        CreateMap<Post, CreatePost>().ReverseMap();
    }
}
