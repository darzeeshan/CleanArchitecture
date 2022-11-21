using AutoMapper;
using Cone.InventoryManagement.Web.Contracts.Persistence;
using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Services.Base;

namespace Cone.InventoryManagement.Web.Services.Clients
{
    public class ClientConnectionService : BaseHttpService, IClientConnectionService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;

        public ClientConnectionService(IClient httpClient, ILocalStorageService localStorage, IMapper mapper) : base(httpClient, localStorage)
        {
            _httpClient = httpClient;
            _localStorageService = localStorage;
            _mapper = mapper;
        }

        public async Task<List<ClientConnectionDetailedVM>> GetClientConnection()
        {
            try
            {
                var query = await _client.ClientConnectionAllAsync();

                return _mapper.Map<List<ClientConnectionDetailedVM>>(query);
            }
            catch (ApiException ex)
            {
                return null; //return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ClientConnectionDetailedVM> ClientConnectionDetail(int Id)
        {
            try
            {
                var query = await _client.ClientConnectionGETAsync(Id);

                return _mapper.Map<ClientConnectionDetailedVM>(query);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<Response<int>> ClientConnectionDelete(int Id)
        {
            try
            {
                var result = await _client.ClientConnectionDELETEAsync(Id);

                return _mapper.Map<Response<int>>(result);
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> ClientConnectionCreate(BaseClientConnectionVM model)
        {
            try
            {
                var response = new Response<int>();
                BaseClientConnectionDto dto = _mapper.Map<BaseClientConnectionDto>(model);

                var result = await _client.ClientConnectionPOSTAsync(dto);

                return _mapper.Map<Response<int>>(result);
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ClientConnectionEditVM> ClientConnectionEdit(int Id)
        {
            try
            {
                var query = await _client.ClientConnectionGETAsync(Id);

                return _mapper.Map<ClientConnectionEditVM>(query);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<Response<int>> ClientConnectionEdit(int Id, ClientConnectionEditVM model)
        {
            try
            {
                var response = new Response<int>();
                ClientConnectionEditDto dto = _mapper.Map<ClientConnectionEditDto>(model);
                var result = await _client.ClientConnectionPUTAsync(Id, dto); //if some err check 005 MVC video @ 7:10

                return _mapper.Map<Response<int>>(result);
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<ClientConnectionForSpecificSetupVM>> ClientConnectionForSpecificSetup(int Id)
        {
            try
            {
                var query = await _client.GetClientConnectionForSpecificSetupAsync(Id);

                return _mapper.Map<List<ClientConnectionForSpecificSetupVM>>(query);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

    }
}
