using demo2.Application.Behaviors;
using demo2.Domain.AggregatesModel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo2.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Response>
    {
        private readonly IBlogRepository _blogRepository;
        

        public CreateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;           
        }
        
        public async Task<Response> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog(request.Url);

            await _blogRepository.AddAsync(blog);

            return new Response("Book criado com sucesso");
        }
    }


    
}
