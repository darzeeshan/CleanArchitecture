using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands
{
    public class CreateClientSetupCommandRequest : IRequest<BaseCommandResponse>
    {
        public BaseClientSetupDto createClientSetupDto { get; set; }
    }
}
