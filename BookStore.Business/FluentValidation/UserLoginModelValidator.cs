using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username field cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty")
                                    .MinimumLength(8).WithMessage("The length of ‘Password’ must be 8 characters or fewer.");
        }
    }
}
