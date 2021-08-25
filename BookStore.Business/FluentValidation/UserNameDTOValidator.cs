using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class UserNameDTOValidator : AbstractValidator<UserNameDTO>
    {
        public UserNameDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName field cannot be empty");
        }
    }
}
