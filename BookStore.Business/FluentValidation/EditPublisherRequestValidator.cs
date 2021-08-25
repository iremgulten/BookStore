using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class EditPublisherRequestValidator : AbstractValidator<EditPublisherRequest>
    {
        public EditPublisherRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id field cannot be empty");
            RuleFor(x => x.PublisherName).NotEmpty().WithMessage("Publisher Name field cannot be empty");
        }
    }
}
