using demo1.Domain.AggregatesModel.BookAggregate;
using demo1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastructure.Repository
{
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(DemoDbContext dbContext) : base(dbContext)
        {
        }

        public Book GetByIdWithItems(int id)
        {
            return _dbContext.Book.FirstOrDefault();
        }

        public Task<Book> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Book
                .FirstOrDefaultAsync();
        }
    }
}
