using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net7_Web_API.Dtos.Comments;
using Net7_Web_API.Dtos.Posts;

namespace Net7_Web_API.Services.PostsService
{
    public interface IPostsService
    {
        Task<ServiceResponse<List<GetPostsDto>>> GetAllPosts();
        Task<ServiceResponse<GetPostsDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostsDto>>> AddPost(AddPostsDto newPost);
        Task<ServiceResponse<GetPostsDto>> UpdatePost(UpdatePostsDto updatedPost);
        Task<ServiceResponse<List<GetPostsDto>>> DeletePost(int id);

        Task<ServiceResponse<List<GetPostsDto>>> AddCommentToPost(AddCommentToPostDto newPost);

        
    }
}