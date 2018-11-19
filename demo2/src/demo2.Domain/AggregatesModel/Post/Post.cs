using demo2.Domain.SeedWork;
using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class Post : Entity, IAggregateRoot
    {
        //public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<PostTag> PostTags { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
