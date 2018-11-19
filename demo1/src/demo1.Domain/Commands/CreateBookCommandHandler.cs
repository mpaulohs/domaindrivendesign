using demo1.Domain.AggregatesModel.BookAggregate;
using demo1.Domain.Behaviors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace demo1.Domain.Commands
{

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title);

            await _bookRepository.AddAsync(book);

            return new Response("Book criado com sucesso");
        }
    }
}
