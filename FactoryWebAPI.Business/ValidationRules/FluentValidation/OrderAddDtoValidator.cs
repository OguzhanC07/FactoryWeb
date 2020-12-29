using FactoryWebAPI.DTO.DTOs.OrderDetailDtos;
using FluentValidation;

namespace FactoryWebAPI.Business.ValidationRules.FluentValidation
{
    public class OrderAddDtoValidator : AbstractValidator<OrderAddDto>
    {
        public OrderAddDtoValidator()
        {
            RuleFor(I => I.DealerId).GreaterThanOrEqualTo(0).WithMessage("Lütfen düzgün bayi id giriniz.");
            RuleFor(I => I.ProductId).GreaterThanOrEqualTo(0).WithMessage("Lütfen düzgün ürün id giriniz.");

            RuleFor(I => I.NumberOfOrders).GreaterThanOrEqualTo(1).WithMessage("En az 1 sipariş verilebilir.");
        }
    }
}
