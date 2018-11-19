using demo1.Domain.SeedWork;
using System.Threading.Tasks;

namespace demo1.Domain.AggregatesModel.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByIdWithItems(int id);
    }
}
