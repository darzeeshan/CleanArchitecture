using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands
{
    public class UpdateStatusClientSetupCommandRequest : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }

        public ClientSetupStatusChangeDto updateStatus { get; set; }
    }
}
