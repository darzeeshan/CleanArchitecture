using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands
{
    public class UpdateClientSetupCommandRequest : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }

        public ClientSetupEditDto updateClientSetupDto { get; set; }
    }
}
