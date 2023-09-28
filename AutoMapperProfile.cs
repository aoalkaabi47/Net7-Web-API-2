using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net7_Web_API.Dtos.Comments;

namespace Net7_Web_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Posts, GetPostsDto>();
            CreateMap<AddPostsDto, Posts>();
            CreateMap<Comments, GetCommentDto>();
            CreateMap<Comments, AddCommentToPostDto>();
        }
    }
}