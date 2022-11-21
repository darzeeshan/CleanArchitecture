using Cone.InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Application.Contracts.Persistence.Clients
{
    public interface IClientSetupRepository : IGenericRepository<tblMapClientSetup>
    {
    }
}
