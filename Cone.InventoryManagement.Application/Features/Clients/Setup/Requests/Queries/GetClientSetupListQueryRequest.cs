using Cone.InventoryManagement.Application.DTOs.Clients;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Queries
{
    public class GetClientSetupListQueryRequest : IRequest<List<ClientSetupDetailedDto>>
    {
    }
}
