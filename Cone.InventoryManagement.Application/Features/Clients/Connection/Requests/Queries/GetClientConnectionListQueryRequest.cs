using Cone.InventoryManagement.Application.DTOs.Clients;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries
{
    public class GetClientConnectionListQueryRequest : IRequest<List<ClientConnectionDetailedDto>>
    {
    }
}
