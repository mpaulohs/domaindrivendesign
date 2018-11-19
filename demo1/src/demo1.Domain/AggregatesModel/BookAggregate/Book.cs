using demo1.Domain.SeedWork;

namespace demo1.Domain.AggregatesModel.BookAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        public string Title { get; set; }

        public Book() { }
        public Book(string title)
        {
            Title = title;
        }

    }
}
