using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands
{
    public class UpdateClientConnectionCommandRequests : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public ClientConnectionEditDto updateClientConnectionDto { get; set; }
    }
}
