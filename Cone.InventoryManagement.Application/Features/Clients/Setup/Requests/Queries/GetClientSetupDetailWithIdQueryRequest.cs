using Cone.InventoryManagement.Application.DTOs.Clients;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Queries
{
    public class GetClientSetupDetailWithIdQueryRequest : IRequest<ClientSetupDetailedDto>
    {
        public int Id { get; set; }
    }
}
