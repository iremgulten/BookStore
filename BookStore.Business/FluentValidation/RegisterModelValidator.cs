using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username field cannot be empty");
            RuleFor(x => x.Email).EmailAddress()
                                 .NotEmpty().WithMessage("Email field cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty")
                                    .MinimumLength(8).WithMessage("The length of ‘Password’ must be 8 characters or fewer."); 
        }
    }
}
