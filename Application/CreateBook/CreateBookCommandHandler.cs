using Domain.AggregatesModel.BookAggregate;
using MediatR;

namespace Application.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly IBookWriteRepository _bookWriteRepository;

        public CreateBookCommandHandler(
            IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }

        public Task<bool> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            CreateBook(command);

            return Task.FromResult(true);
        }

        public void CreateBook(CreateBookCommand command)
        {
            //_bookWriteRepository.Add(new Book
            //{
            //    ItemId = command.ItemId ?? Guid.NewGuid().ToString(),
            //    Title = command.Title
            //});

            _bookWriteRepository.Update(new Book
            {
                ItemId = command.ItemId,
                Title = command.Title,
            });
        }
    }
}
