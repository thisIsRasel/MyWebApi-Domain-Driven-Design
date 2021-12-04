using Domain;
using Domain.AggregatesModel.BookAggregate;

namespace Infrastructure.Repositories
{
    public class BookRepository
        : IBookWriteRepository, IBookReadRepository
    {
        private readonly IRepository<Book> _repository;

        public BookRepository(
            IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Create(Book book)
        {
            _repository.Insert(book);
        }

        public void Delete(Book book)
        {
            _repository.Delete(book);
        }

        public async Task<Book> GetBookAsync(string itemId)
        {
            var result = await _repository.GetItemAsync(itemId);
            return result;
        }

        public void Update(Book book)
        {
            _repository.Update(book);
        }
    }
}
