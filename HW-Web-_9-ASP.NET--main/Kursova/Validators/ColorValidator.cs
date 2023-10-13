using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Validators
{
    public class ColorValidator:AbstractValidator<DataProject.Data.Entitys.Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).NotNull().WithMessage("{PropertyName} not valid");
        }
    }
}
