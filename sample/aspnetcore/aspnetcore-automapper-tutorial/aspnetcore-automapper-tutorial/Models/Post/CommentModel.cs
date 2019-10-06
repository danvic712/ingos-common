using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_automapper_tutorial.Models.Post
{
    public class CommentModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }
    }
}