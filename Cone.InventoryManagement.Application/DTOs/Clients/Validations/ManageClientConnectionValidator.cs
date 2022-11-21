using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using FluentValidation;

namespace Cone.InventoryManagement.Application.DTOs.Clients.Validations
{
    //Validate child table based on parent table
    //stackoverflow.com/questions/18720105/child-model-validation-using-parent-model-values-fluent-validation-mvc4

    public class ClientCreateConnectionValidator : AbstractValidator<BaseClientConnectionDto>
    {
        public ClientCreateConnectionValidator()
        {
            RuleFor(x => x.SetupId)
                .NotEmpty().WithName("Client").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"));

            RuleFor(x => x.ConnectionType)
                .NotEmpty().WithName("Connection type").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                .Must(DTOsValidation.ValidConnection).WithName("Connection type").WithMessage(String.Format(Messages.Validation(3), "{PropertyName}"));

            RuleFor(x => x.Username)
                .MaximumLength(20).WithName("User name").WithMessage(String.Format(Messages.Validation(2), "20", "{PropertyName}"));

            RuleFor(x => x.Password)
                .MaximumLength(20).WithName("Password").WithMessage(String.Format(Messages.Validation(2), "20", "{PropertyName}"));

            RuleFor(x => x.Port)
                .MaximumLength(5).WithName("Port").WithMessage(String.Format(Messages.Validation(2), "5", "{PropertyName}"));


            When(x => x.ConnectionType == 1, () =>
            {
                RuleFor(x => x.Key)
                    .NotEmpty().WithName("Key").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                    .MaximumLength(100).WithMessage(String.Format(Messages.Validation(2), "100", "{PropertyName}"));
            });              

            When(x => x.ConnectionType > 1 && x.ConnectionType < 4, () => {
                RuleFor(x => x.Key)
                    .NotEmpty().WithName("Url").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"))
                    .MaximumLength(100).WithMessage(String.Format(Messages.Validation(2), "100", "{PropertyName}"));

                RuleFor(x => x.Username)
                    .NotEmpty().WithName("User name").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"));

                RuleFor(x => x.Password)
                    .NotEmpty().WithName("Password").WithMessage(String.Format(Messages.Validation(1), "{PropertyName}"));
            });
        }
    }

    public class ClientEditConnectionValidator : AbstractValidator<ClientConnectionEditDto>
    {
        public ClientEditConnectionValidator()
        {
            Include(new ClientCreateConnectionValidator());
        }
    }
}
