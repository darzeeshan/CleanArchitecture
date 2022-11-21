using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands
{
    public class DeleteClientSetupCommandRequest : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
