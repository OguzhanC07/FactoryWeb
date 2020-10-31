using FactoryWebAPI.DTO.DTOs.DealerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.ValidationRules.FluentValidation
{
    public class DealerAddDtoValidator : AbstractValidator<DealerAddDto>
    {
        public DealerAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(I => I.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez");
            RuleFor(I => I.AppUserId).NotNull().WithMessage("AppUserId boş olamaz");
        }
    }
}
