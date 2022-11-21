using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands
{
    public class DeleteClientConnectionCommandRequest : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
