using demo2.Domain.SeedWork;

namespace demo2.Domain.AggregatesModel
{
    public class BlogImage : Entity, IAggregateRoot
    {
       // public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
