
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class UserIdDTOValidator : AbstractValidator<UserIdDTO>
    {
        public UserIdDTOValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID field cannot be empty");
        }
    }
}
