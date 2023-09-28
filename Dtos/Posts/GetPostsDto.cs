using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net7_Web_API.Dtos.Posts
{
    public class GetPostsDto
    {
        public int Id { get; set;} = 0;

        public string Title { get; set;} = "";

        public string Content { get; set;} = "";

        public List<GetCommentDto>? MyComments { get; set; }
    }
}