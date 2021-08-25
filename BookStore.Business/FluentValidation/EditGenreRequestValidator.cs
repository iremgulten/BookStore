using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.GenresDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class EditGenreRequestValidator : AbstractValidator<EditGenreRequest>
    {
        public EditGenreRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id field cannot be empty");
            RuleFor(x => x.GenreName).NotEmpty().WithMessage("Genre field cannot be empty");
        }
    }
}
