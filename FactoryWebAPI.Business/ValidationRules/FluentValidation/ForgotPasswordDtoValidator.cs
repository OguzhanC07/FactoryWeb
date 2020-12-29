using FactoryWebAPI.DTO.DTOs.ForgotPasswordDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.ValidationRules.FluentValidation
{
    class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordDtoValidator()
        {
            RuleFor(I => I.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(I => I.Code).NotEmpty().WithMessage("Kod alanı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        }
    }
}
