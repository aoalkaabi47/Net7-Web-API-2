using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net7_Web_API.Models
{
    public class Posts
    {
        public int Id { get; set;} = 0;

        public string Title { get; set;} = "";

        public string Content { get; set;} = "";

        public List<Comments>? MyComments { get; set; }
        public User? User { get; set;}


    }
}