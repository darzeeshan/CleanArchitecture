using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Cone.InventoryManagement.Persistence.Repositories.Client
{
    public class ClientConnectionRepository : GenericRepository<tblMapClientConnection>, IClientConnectionRepository
    {
        private readonly ConeDatabaseContext _dbContext;

        public ClientConnectionRepository(ConeDatabaseContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<ClientConnectionForSpecificSetupDto>> GetClientConnectionForSpecificSetup(int Id)
        {
            var result =  await _dbContext.tblMapClientConnection.Where(q => q.intClientSetupId == Id)
                .Include(q => q.mapClientSetup)
                .Select(col => new ClientConnectionForSpecificSetupDto
                {
                    ConnectionId = col.intClientConnectionId,
                    SetupId = col.intClientSetupId,
                    ClientId = col.mapClientSetup.txtClientId,
                    ClientName = col.mapClientSetup.txtClientName,
                    ConnectionType = col.bytConnectionType,
                    Key = col.txtKey,
                    Username = col.txtUsername,
                    Password = col.txtPassword,
                    Port = col.txtPort,
                    DateTime = col.dtDateTime,
                    LastUpdated = col.dtLastUpdated
                })
                .ToListAsync();
            #region Comment
            //var result1 = (from a in _dbContext.tblMapClientConnection
            //              join b in _dbContext.tblMapClientSetup
            //              on a.intClientSetupId equals b.intClientSetupId
            //              where a.intClientSetupId == Id
            //              select new
            //              {
            //                  ConnectionId = a.intClientConnectionId,
            //                  SetupId = a.intClientSetupId,
            //                  ClientId = b.txtClientId,
            //                  ClientName = b.txtClientName,
            //                  ConnectionType = a.bytConnectionType,
            //                  Key = a.txtKey,
            //                  Username = a.txtUsername,
            //                  Password = a.txtPassword,
            //                  Port = a.txtPort,
            //                  DateTime = a.dtDateTime,
            //                  LastUpdated = a.dtLastUpdated
            //              }).ToListAsync();
            #endregion

            return result;
        }
    }
}



