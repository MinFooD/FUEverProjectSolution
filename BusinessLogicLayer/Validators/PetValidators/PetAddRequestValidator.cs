using BusinessLogicLayer.Dtos.PetDtos;
using FluentValidation;

namespace BusinessLogicLayer.Validators.PetValidators;

public class PetAddRequestValidator : AbstractValidator<PetAddRequest>
{
    public PetAddRequestValidator()
    {
        RuleFor(x => x.PetName)
            .NotEmpty().WithMessage("Tên thú cưng không được để trống.")
            .MaximumLength(50).WithMessage("Tên thú cưng không được vượt quá 50 ký tự.");

        RuleFor(x => x.Breed)
            .NotEmpty().WithMessage("Giống loài không được để trống.")
            .MaximumLength(50).WithMessage("Giống loài không được vượt quá 50 ký tự.");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(0).WithMessage("Tuổi phải lớn hơn hoặc bằng 0.")
            .LessThanOrEqualTo(50).WithMessage("Tuổi không được vượt quá 50.");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Cân nặng phải lớn hơn 0.")
            .LessThanOrEqualTo(500).WithMessage("Cân nặng không được vượt quá 500 kg.");

        RuleFor(x => x.SpecialPathology)
            .MaximumLength(200).WithMessage("Bệnh lý đặc biệt không được vượt quá 200 ký tự.")
            .When(x => x.SpecialPathology != null);

        RuleFor(x => x.Diet)
            .MaximumLength(200).WithMessage("Chế độ ăn không được vượt quá 200 ký tự.")
            .When(x => x.Diet != null);

        RuleFor(x => x.Habit)
            .MaximumLength(200).WithMessage("Thói quen không được vượt quá 200 ký tự.")
            .When(x => x.Habit != null);

        RuleFor(x => x.OtherRequest)
            .MaximumLength(500).WithMessage("Yêu cầu khác không được vượt quá 500 ký tự.")
            .When(x => x.OtherRequest != null);

        RuleFor(x => x.HealthDetail)
            .MaximumLength(500).WithMessage("Chi tiết sức khỏe không được vượt quá 500 ký tự.")
            .When(x => x.HealthDetail != null);

        RuleFor(x => x.Image)
            .MaximumLength(200).WithMessage("Đường dẫn ảnh không được vượt quá 200 ký tự.");
    }
}
