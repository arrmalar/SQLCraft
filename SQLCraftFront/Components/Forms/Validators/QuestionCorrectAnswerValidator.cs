using FluentValidation;
using SQLCraft.Models;

namespace SQLCraftFront.Components.Forms.Validators
{
    public class QuestionCorrectAnswerValidator : AbstractValidator<QuestionCorrectAnswer>
    {
        public QuestionCorrectAnswerValidator()
        {
            RuleFor(questionCorrectAnswer => questionCorrectAnswer.CorrectAnswer).NotEmpty().WithMessage("Answer can not be empty!");
        }
    }
}
