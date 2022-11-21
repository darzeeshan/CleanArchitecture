using Cone.InventoryManagement.Application.DTOs.Clients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries
{
    public class GetClientConnectionForSpecificSetupQueryRequest : IRequest<List<ClientConnectionForSpecificSetupDto>>
    {
        public int Id { get; set; }
    }
}
