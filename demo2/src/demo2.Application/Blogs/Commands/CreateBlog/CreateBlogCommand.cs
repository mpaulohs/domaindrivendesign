using demo2.Application.Behaviors;
using MediatR;
using System.Runtime.Serialization;

namespace demo2.Application.Blogs.Commands.CreateBlog
{
    [DataContract]
    public class CreateBlogCommand : IRequest<Response>
    {
        [DataMember]
        public string Url { get; set; }

        public CreateBlogCommand() { }
        public CreateBlogCommand(string url)
        {
            Url = url;
        }
    }
}
