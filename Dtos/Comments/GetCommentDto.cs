using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net7_Web_API.Dtos.Comments
{
    public class GetCommentDto
    {
        public int Id { get; set;} = 0;

        public string Text { get; set;} = "";
    }
}