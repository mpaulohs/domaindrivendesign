using demo1.Domain.Behaviors;
using MediatR;
using System.Runtime.Serialization;

namespace demo1.Domain.Commands
{
    [DataContract]
    public class CreateBookCommand : IRequest<Response>
    {
        [DataMember]
        public string Title { get; set; }
        

        public CreateBookCommand() { }

        public CreateBookCommand(string title)
        {
            Title = title;
        }
    }
}
