using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.ImagePath).Must(EndWithExtension).WithMessage("Görsel uzantısı yalnızca 'jpg' olabilir.").ToString();
        }

        private bool EndWithExtension(string arg)
        {
            return arg.EndsWith(".jpg");
        }
    }
}
