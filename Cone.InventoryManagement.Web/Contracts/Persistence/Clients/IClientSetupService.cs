using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Services.Base;

namespace Cone.InventoryManagement.Web.Contracts.Persistence.Clients
{
    public interface IClientSetupService
    {
        Task<List<ClientSetupDetailedVM>> GetClientSetup();

        Task<ClientSetupDetailedVM> ClientSetupDetail(int Id);

        Task<Response<int>> ClientSetupDelete(int Id);

        Task<Response<int>> ClientSetupCreate(BaseClientSetupVM model);

        Task<ClientSetupEditVM> ClientSetupEdit(int Id);

        Task<Response<int>> ClientSetupEdit(int Id, ClientSetupEditVM model);

        Task<Response<int>> ClientSetupChangeStatus(int Id);
    }
}
