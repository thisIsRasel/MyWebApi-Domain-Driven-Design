using Domain.AggregatesModel.BookAggregate;
using GraphQL.Types;

namespace Domain.GraphqlTypes
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";

            Field(x => x.ItemId, type: typeof(IdGraphType)).Description("The ID of the Book.");
            Field(x => x.Title).Description("The title of Book");
        }
    }
}
