using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Application.Contracts.Persistence.Clients
{
    public interface IClientConnectionRepository : IGenericRepository<tblMapClientConnection>
    {
        Task<List<ClientConnectionForSpecificSetupDto>> GetClientConnectionForSpecificSetup(int Id);
    }
}
