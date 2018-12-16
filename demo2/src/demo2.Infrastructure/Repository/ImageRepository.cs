using demo2.Domain.AggregatesModel.ImageStore;
using demo2.Infrastructure.Data;

namespace demo2.Infrastructure.Repository
{
    public class ImageRepository : EfRepository<ImageStore>, IImageRepository
    {
        public ImageRepository(Demo2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
