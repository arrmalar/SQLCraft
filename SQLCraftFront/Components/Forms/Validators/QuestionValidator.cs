using FluentValidation;
using SQLCraft.Models;

namespace SQLCraftFront.Components.Forms.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator() {
            RuleFor(question => question.QuestionText).NotEmpty().WithMessage("Question can not be empty!");
            RuleFor(question => question.QuestionLevelID).NotEmpty().WithMessage("Question level can not be empty!");
            RuleFor(question => question.QuestionCorrectAnswer).SetValidator(new QuestionCorrectAnswerValidator());
            RuleFor(question => question.DBSchemaID).NotEmpty().WithMessage("DBSchema can not be empty!");
        }
    }
}
