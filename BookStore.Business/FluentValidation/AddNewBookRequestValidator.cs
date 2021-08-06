using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.BooksDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewBookRequestValidator : AbstractValidator<AddNewBookRequest>
    {
        public AddNewBookRequestValidator()
        {
            RuleFor(x => x.Isbn).NotEmpty().WithMessage("Isbn field cannot be empty").MaximumLength(13).WithMessage("The length of ‘ISBN’ must be 13 characters or fewer. ");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title field cannot be empty").MaximumLength(100).WithMessage("The length of ‘Title’ must be 100 characters or fewer. ");
            RuleFor(x => x.Author).NotEmpty().WithMessage("AuthorId field cannot be empty");
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("PublisherId field cannot be empty");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("GenreId field cannot be empty");
        }
    }
}
