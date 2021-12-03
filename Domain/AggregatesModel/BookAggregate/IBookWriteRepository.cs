namespace Domain.AggregatesModel.BookAggregate
{
    public interface IBookWriteRepository
    {
        void Add(Book book);

        void Update(Book book);

        void Delete(Book book);
    }
}
