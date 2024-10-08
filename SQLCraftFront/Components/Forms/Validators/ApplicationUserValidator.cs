using FluentValidation;
using SQLCraft.Models.DTO.Identity;
using SQLCraftFront.Providers.IProviders;

namespace SQLCraftFront.Components.Forms.Validators
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        private readonly IRepositoryProvider _repositoryProvider;

        public ApplicationUserValidator(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email is not valid.")
                .MustAsync(async (email, cancellationToken) => {
                        var exists = await DoesEmailExist(email);
                        return !exists;
                    })
                .WithMessage("This email is already in use.");

           /* RuleFor(registerDTO => registerDTO.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$")
                .WithMessage("Passwords must have at least 6 characters, one uppercase ('A'-'Z'), one lowercase ('a'-'z'), one digit ('0'-'9'), and one non-alphanumeric character.");
*/        }

        // Asynchronous method to call the API and check if email exists
        private async Task<bool> DoesEmailExist(string email)
        {
            return await _repositoryProvider.ApplicationUserRepository.CheckIfEmailExists(email);
        }
    }
}

