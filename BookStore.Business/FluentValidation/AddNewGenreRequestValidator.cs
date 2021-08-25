using BookStore.Business.DataTransferObjects.GenresDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewGenreRequestValidator : AbstractValidator<AddNewGenreRequest>
    {
        public AddNewGenreRequestValidator()
        {
            RuleFor(x => x.GenreName).NotEmpty().WithMessage("Genre field cannot be empty");
        }
    }
}
