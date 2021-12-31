using Domain.AggregatesModel.BookAggregate;
using MediatR;

namespace Application.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;

        public CreateBookCommandHandler(
            IBookWriteRepository bookWriteRepository,
            IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<bool> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await GetBookAsync(command.ItemId);

            PrepareBook(book, command);

            if(string.IsNullOrWhiteSpace(book.ItemId))
            {
                book.ItemId = command.ItemId ?? Guid.NewGuid().ToString();
                _bookWriteRepository.Create(book);
                return true;
            }

            _bookWriteRepository.Update(book);
            return true;
        }

        private async Task<Book> GetBookAsync(string itemId)
        {
            var book = await _bookReadRepository.GetBookAsync(itemId);

            if(book == null)
            {
                book = new Book();
            }

            return book;
        }

        private void PrepareBook(Book book, CreateBookCommand command)
        {
            book.Title = command.Title;
        }
    }
}
