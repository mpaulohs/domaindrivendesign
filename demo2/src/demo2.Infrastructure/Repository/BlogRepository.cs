using demo2.Domain.AggregatesModel;
using demo2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace demo2.Infrastructure.Repository
{
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(Demo2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
