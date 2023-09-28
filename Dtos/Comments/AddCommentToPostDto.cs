using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net7_Web_API.Dtos.Comments
{
    public class AddCommentToPostDto
    {
        
        public string Text { get; set;} = "";

        public int PostsId { get; set;}
    }
}