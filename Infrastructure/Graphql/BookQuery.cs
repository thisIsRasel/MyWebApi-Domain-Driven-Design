using Domain.AggregatesModel.BookAggregate;
using Domain.GraphqlTypes;
using GraphQL;
using GraphQL.Types;

namespace Infrastructure.Graphql
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookReadRepository bookReadRepository)
        {
            FieldAsync<BookType>(
                "book",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var book = await bookReadRepository.GetBookAsync(id);
                    return book;
                });
        }
    }
}
