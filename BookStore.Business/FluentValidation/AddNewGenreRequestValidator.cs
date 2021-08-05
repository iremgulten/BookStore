using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.GenresDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewGenreRequestValidator : AbstractValidator<AddNewGenreRequest>
    {
        public AddNewGenreRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Genre field cannot be empty");
        }
    }
}
