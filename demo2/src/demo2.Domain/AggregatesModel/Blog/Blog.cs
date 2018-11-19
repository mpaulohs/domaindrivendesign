using demo2.Domain.SeedWork;
using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class Blog : Entity, IAggregateRoot
    {       
        public string Url { get; set; }
        public BlogImage BlogImage { get; set; }
        public List<Post> Posts { get; set; }

        public Blog() { }
        public Blog(string url)
        {
            Url = url;
        }
    }
}
