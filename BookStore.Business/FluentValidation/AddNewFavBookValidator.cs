using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewFavBookValidator : AbstractValidator<AddNewFavBook>
    {
        public AddNewFavBookValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Book ID field cannot be empty");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID field cannot be empty");
        }
    }
}
