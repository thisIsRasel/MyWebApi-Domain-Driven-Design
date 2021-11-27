using Domain.AggregatesModel.BookAggregate;
using MediatR;

namespace Application.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, string>
    {
        private readonly IBookWriteRepository _bookWriteRepository;

        public CreateBookCommandHandler(
            IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }

        public Task<string> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            CreateBook();

            return Task.FromResult<string>("Something in command handler!");
        }

        public void CreateBook()
        {
            _bookWriteRepository.Add(new Book
            {
                ItemId = Guid.NewGuid().ToString(),
                Title = "Mathematics"
            });
        }
    }
}
