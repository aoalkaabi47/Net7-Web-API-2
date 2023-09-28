using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Net7_Web_API.Services.PostsService;

namespace Net7_Web_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("(list)")]
        public async Task<ActionResult<ServiceResponse<List<GetPostsDto>>>> GetAllPosts(){
            return Ok(await _postsService.GetAllPosts());
        }

      [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPostsDto>>> GetPost(int id){
            return Ok(await _postsService.GetPostById(id));
        }

        [HttpPost("(create a new post)")]
        public async Task<ActionResult<ServiceResponse<List<GetPostsDto>>>> AddPost(AddPostsDto newPosts){
            return Ok(await _postsService.AddPost(newPosts));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPostsDto>>>> UpdatePosts(UpdatePostsDto updatedPost){
            return Ok(await _postsService.UpdatePost(updatedPost));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPostsDto>>> DeletePost(int id){
            return Ok(await _postsService.DeletePost(id));
        }

    }
}