using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Persistence.Repositories.Client
{
    public class ClientSetupRepository : GenericRepository<tblMapClientSetup>, IClientSetupRepository
    {
        private readonly ConeDatabaseContext _dbContext;

        public ClientSetupRepository(ConeDatabaseContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
