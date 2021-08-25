using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class DeleteUserFavValidator : AbstractValidator<DeleteUserFav>
    {
        public DeleteUserFavValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Book ID field cannot be empty");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName field cannot be empty");
        }
    }
}
