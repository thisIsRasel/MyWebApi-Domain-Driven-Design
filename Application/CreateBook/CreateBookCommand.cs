using MediatR;

namespace Application.CreateBook
{
    public class CreateBookCommand : IRequest<string>
    {
        public string Title { get; set; } = default!;
    }
}
