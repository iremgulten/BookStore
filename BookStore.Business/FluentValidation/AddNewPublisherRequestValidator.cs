using BookStore.Business.DataTransferObjects.PublishersDTO;
using FluentValidation;

namespace BookStore.Business.FluentValidation
{
    public class AddNewPublisherRequestValidator : AbstractValidator<AddNewPublisherRequest>
    {
        public AddNewPublisherRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Publisher Name field cannot be empty");
        }
    }
}
