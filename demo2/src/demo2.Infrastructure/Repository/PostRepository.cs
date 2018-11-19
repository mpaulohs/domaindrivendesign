using demo2.Domain.AggregatesModel;
using demo2.Infrastructure.Data;

namespace demo2.Infrastructure.Repository
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(Demo2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
