using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Services.Base;

namespace Cone.InventoryManagement.Web.Contracts.Persistence.Clients
{
    public interface IClientConnectionService
    {
        Task<List<ClientConnectionDetailedVM>> GetClientConnection();

        Task<ClientConnectionDetailedVM> ClientConnectionDetail(int Id);

        Task<Response<int>> ClientConnectionDelete(int Id);

        Task<Response<int>> ClientConnectionCreate(BaseClientConnectionVM model);

        Task<ClientConnectionEditVM> ClientConnectionEdit(int Id);

        Task<Response<int>> ClientConnectionEdit(int Id, ClientConnectionEditVM model);

        Task<List<ClientConnectionForSpecificSetupVM>> ClientConnectionForSpecificSetup(int Id);
    }
}
