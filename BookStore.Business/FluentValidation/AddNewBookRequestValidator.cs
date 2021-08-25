using BookStore.Business.DataTransferObjects.BooksDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewBookRequestValidator : AbstractValidator<AddNewBookRequest>
    {
        public AddNewBookRequestValidator()
        {
            RuleFor(x => x.Isbn).NotEmpty().WithMessage("Isbn field cannot be empty").MaximumLength(13).WithMessage("The length of ‘ISBN’ must be 13 characters or fewer. ");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title field cannot be empty").MaximumLength(100).WithMessage("The length of ‘Title’ must be 100 characters or fewer. ");
            //RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Author Id field cannot be empty").GreaterThan(0).WithMessage("‘Author Id’ must be greater than 0");
            //RuleFor(x => x.PublisherId).NotEmpty().WithMessage("Publisher Id field cannot be empty").GreaterThan(0).WithMessage("‘Author Id’ must be greater than 0");
            //RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre Id field cannot be empty").GreaterThan(0).WithMessage("‘Author Id’ must be greater than 0");
        }
    }
}
