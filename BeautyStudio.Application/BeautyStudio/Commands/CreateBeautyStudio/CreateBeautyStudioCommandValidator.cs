using BeautyStudio.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.BeautyStudio.Commands.CreateBeautyStudio
{
    public class CreateBeautyStudioCommandValidator : AbstractValidator<CreateBeautyStudioCommand>
    {
        public CreateBeautyStudioCommandValidator(IBeautyStudioRepository repository)
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("The name cannot be empty")
                .MinimumLength(2).WithMessage("The name should have atleast 2 characters")
                .MaximumLength(80).WithMessage("The name shuld have maximum 80 characters")
                .Custom((value, context) =>
                {
                    var existingBeautyStudio = repository.GetByName(value).Result;

                    if (existingBeautyStudio != null)
                        context.AddFailure($"{value} is not a unique name among beauty studios");
                });
        }
    }
}
