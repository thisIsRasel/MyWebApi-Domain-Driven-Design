using Domain;
using Domain.AggregatesModel.BookAggregate;

namespace Infrastructure.Repositories
{
    public class BookWriteRepository : IBookWriteRepository
    {
        private readonly IRepository<Book> _repository;

        public BookWriteRepository(
            IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Add(Book book)
        {
            _repository.Insert(book);
        }

        public void Delete(Book book)
        {
            _repository.Delete(book);
        }

        public void Update(Book book)
        {
            _repository.Update(book);
        }
    }
}
