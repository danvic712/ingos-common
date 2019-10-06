using System;

namespace aspnetcore_automapper_tutorial.ViewModels.Post
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public long SerialNo { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public short CategoryCode { get; set; }

        public string Category => CategoryCode == 1001 ? ".NET" : "杂谈";

        public string ReleaseDate { get; set; }

        public short CommentCounts { get; set; }

        public virtual int Count { get; set; }
    }
}