using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net7_Web_API.Dtos.Comments;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Net7_Web_API.Services.PostsService
{
    public class PostsService : IPostsService
    {
  
         private static List<Posts> AllPosts = new List<Posts>(){
            new Posts{Id = 0, Title = "First Post"},
            new Posts{Id = 1, Title = "Second Post"}

        };
        
        public IMapper _mapper { get; }
        private readonly DataContext _context;

        public PostsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<ServiceResponse<List<GetPostsDto>>> AddPost(AddPostsDto newPost)
        {
            var serviceResponse= new ServiceResponse<List<GetPostsDto>>();
            var Post = _mapper.Map<Posts>(newPost);
            
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
            await _context.Posts.Select(c => _mapper.Map<GetPostsDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPostsDto>>> GetAllPosts()
        {
            var serviceResponse= new ServiceResponse<List<GetPostsDto>>();
            var dbPosts = await _context.Posts.Include(c => c.MyComments).ToListAsync();
            serviceResponse.Data = dbPosts.Select(c => _mapper.Map<GetPostsDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostsDto>> GetPostById(int id)
        {
            var serviceResponse= new ServiceResponse<GetPostsDto>();
            var dbPost = await _context.Posts.FirstOrDefaultAsync(c => c.Id == id)!;
            serviceResponse.Data = _mapper.Map<GetPostsDto>(dbPost);
            return serviceResponse;             
        }

        public async Task<ServiceResponse<GetPostsDto>> UpdatePost(UpdatePostsDto updatedPost)
        {
            var serviceResponse= new ServiceResponse<GetPostsDto>();

            try{

            var Post = await _context.Posts.FirstOrDefaultAsync(c => c.Id == updatedPost.Id)!;

            Post.Title = updatedPost.Title;
            Post.Content = updatedPost.Content;
            //Post.Comments = updatedPost.Comments;
            serviceResponse.Data = _mapper.Map<GetPostsDto>(Post);

            await _context.SaveChangesAsync();
            }
            catch (Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;  
        
        }

        public async Task<ServiceResponse<List<GetPostsDto>>> DeletePost(int id)
        {
            var serviceResponse= new ServiceResponse<List<GetPostsDto>>();

            try{

            var Post = await _context.Posts.FirstOrDefaultAsync(c => c.Id == id);
            _context.Posts.Remove(Post);

            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Posts.Select(c => _mapper.Map<GetPostsDto>(c)).ToListAsync();
            }
            catch (Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse; 
        }

        public Task<ServiceResponse<List<GetPostsDto>>> AddCommentToPost(AddCommentToPostDto newPost)
        {
            throw new NotImplementedException();
        }

        // public async Task<ServiceResponse<List<GetPostsDto>>> AddCommentToPost(AddCommentToPostDto newComment)
        // {
        //     var serviceResponse= new ServiceResponse<List<GetPostsDto>>();
        //     var Post = await _context.Posts
        //             .Include(c => c.MyComments)
        //             .FirstOrDefaultAsync(c => c.Id == newComment.PostsId);
        //     var comment = await _context.Posts.FirstOrDefaultAsync();

        //     Post.MyComments!.Add(newComment);
        //         await _context.SaveChangesAsync();
        //         serviceResponse.Data = _mapper.Map<GetPostsDto>(Post);
        //     return serviceResponse;
        // }

    }
}