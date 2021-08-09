﻿using System;
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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Publisher Name field cannot be empty");
        }
    }
}