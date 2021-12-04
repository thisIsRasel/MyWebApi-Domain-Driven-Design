namespace Domain.AggregatesModel.BookAggregate
{
    public interface IBookWriteRepository
    {
        void Create(Book book);

        void Update(Book book);

        void Delete(Book book);
    }
}
