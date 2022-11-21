using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using FluentValidation;

namespace Cone.InventoryManagement.Application.DTOs.Clients.Validations
{
    public class ClientCreateSetupValidator : AbstractValidator<BaseClientSetupDto>
    {
        public ClientCreateSetupValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty().WithName("Status").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                .Must(DTOsValidation.ValidStatus).WithName("Status").WithMessage(String.Format(Messages.Validation(3), "{PropertyName}"));

            RuleFor(x => x.ClientName)
                .NotEmpty().WithName("Client Name").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                .MaximumLength(100).WithMessage(String.Format(Messages.Validation(2), "{MaxLength}", "{PropertyName}"));

            RuleFor(x => x.ClientId)
                .NotEmpty().WithName("Account Id").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                .MaximumLength(15).WithMessage(String.Format(Messages.Validation(2), "{MaxLength}", "{PropertyName}"));

            RuleFor(x => x.FolderLocation)
                .NotEmpty().WithName("Folder Name").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                .MaximumLength(30).WithMessage(String.Format(Messages.Validation(2), "{MaxLength}", "{PropertyName}"));

        }
    }

    public class ClientEditSetupValidator : AbstractValidator<ClientSetupEditDto>
    {
        public ClientEditSetupValidator()
        {
            Include(new ClientCreateSetupValidator());
        }
    }


}
