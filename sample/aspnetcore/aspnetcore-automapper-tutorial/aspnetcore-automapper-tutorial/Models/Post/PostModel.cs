using System;
using System.Collections.Generic;

namespace aspnetcore_automapper_tutorial.Models.Post
{
    public class PostModel
    {
        public Guid Id { get; set; }

        public long SerialNo { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public short CategoryCode { get; set; }

        public bool IsDraft { get; set; }

        public string Content { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual IList<CommentModel> Comments { get; set; }
    }
}