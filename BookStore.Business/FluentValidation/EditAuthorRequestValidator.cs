using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class EditAuthorRequestValidator : AbstractValidator<EditAuthorRequest>
    {
        public EditAuthorRequestValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Author Name field cannot be empty");
        }
    }
}
