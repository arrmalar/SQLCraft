using FluentValidation;
using SQLCraft.Models;

namespace SQLCraftFront.Components.Forms.Validators
{
    public class QuestionLevelValidator : AbstractValidator<QuestionLevel>
    {
        public QuestionLevelValidator()
        {
            RuleFor(questionLevel => questionLevel.Name).NotEmpty().WithMessage("Name can not be empty!");
        }
    }
}
