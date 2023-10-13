using DataProject.Data.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Validators
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.AutoId).NotNull();
        }
    }
}
