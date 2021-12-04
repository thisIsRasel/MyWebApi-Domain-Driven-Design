namespace Domain.AggregatesModel.BookAggregate
{
    public interface IBookReadRepository
    {
        Task<Book> GetBookAsync(string itemId);
    }
}
