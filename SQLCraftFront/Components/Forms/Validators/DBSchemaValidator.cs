using FluentValidation;
using SQLCraft.Models;

namespace SQLCraftFront.Components.Forms.Validators
{
    public class DBSchemaValidator : AbstractValidator<DBSchema>
    {
        public DBSchemaValidator()
        {
            RuleFor(dbSchema => dbSchema.Name).NotEmpty().WithMessage("Name can not be empty!");
        }
    }
}
