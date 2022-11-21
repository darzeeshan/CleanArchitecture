using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands
{
    public class CreateClientConnectionCommandRequest : IRequest<BaseCommandResponse>
    {
        public BaseClientConnectionDto createClientConnectionDto { get; set; }
    }
}
