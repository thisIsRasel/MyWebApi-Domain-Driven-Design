using FluentValidation;
using MediatR;

namespace Application.CreateBook
{
    public class CreateBookCommand : IRequest<bool>
    {
        public string ItemId { get; set; } = default!;

        public string Title { get; set; } = default!;
    }

    public class CreateBookCommandValidator : AbstractValidator <CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(book => book.Title).NotEmpty();
        }
    }
}
