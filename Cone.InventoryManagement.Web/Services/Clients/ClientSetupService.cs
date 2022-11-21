using AutoMapper;
using Cone.InventoryManagement.Web.Contracts.Persistence;
using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Services.Base;

namespace Cone.InventoryManagement.Web.Services.Clients
{
    public class ClientSetupService : BaseHttpService, IClientSetupService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;

        public ClientSetupService(IClient httpClient, ILocalStorageService localStorage, IMapper mapper) : base(httpClient, localStorage)
        {
            _httpClient = httpClient;
            _localStorageService = localStorage;
            _mapper = mapper;
        }

        //Some methods return models. Proper error handling is not possible.
        //So returning null
        public async Task<List<ClientSetupDetailedVM>> GetClientSetup()
        {
            try
            { 
                var query = await _client.ClientSetupAllAsync();

                return _mapper.Map<List<ClientSetupDetailedVM>>(query);
            }
            catch (ApiException ex)
            {
                return null; //return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ClientSetupDetailedVM> ClientSetupDetail(int Id)
        {
            try
            {
                var query = await _client.ClientSetupGETAsync(Id);

                return _mapper.Map<ClientSetupDetailedVM>(query);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<Response<int>> ClientSetupDelete(int Id)
        {
            try
            {
                var result = await _client.ClientSetupDELETEAsync(Id);

                return _mapper.Map<Response<int>>(result);
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> ClientSetupCreate(BaseClientSetupVM model)
        {
            try
            {
                var response = new Response<int>();
                BaseClientSetupDto dto = _mapper.Map<BaseClientSetupDto>(model);

                var result = await _client.ClientSetupPOSTAsync(dto);

                return _mapper.Map<Response<int>>(result);

                #region Commented
                //if (result.StatusCode == 200)
                //{
                //    response.Success = true;
                //    response.Data = result.ReferenceId;
                //}
                //else
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        response.ValidationError = error + Environment.NewLine;
                //    }
                //}

                //return response;
                #endregion
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ClientSetupEditVM> ClientSetupEdit(int Id)
        {
            try
            {
                var query = await _client.ClientSetupGETAsync(Id);

                return _mapper.Map<ClientSetupEditVM>(query);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<Response<int>> ClientSetupEdit(int Id, ClientSetupEditVM model)
        {
            try
            {
                var response = new Response<int>();
                ClientSetupEditDto dto = _mapper.Map<ClientSetupEditDto>(model);
                var result = await _client.ClientSetupPUTAsync(Id, dto); //if some err check 005 MVC video @ 7:10

                return _mapper.Map<Response<int>>(result);

                #region Commented
                //if (result.StatusCode == 200)
                //{
                //    response.Success = true;
                //    response.Data = Id;
                //}
                //else
                //{
                //    response.ValidationError = result.ReferenceId + Environment.NewLine;
                //}
                #endregion

            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> ClientSetupChangeStatus(int Id)
        {
            try
            {
                var response = new Response<int>();
                var result = await _client.ClientSetupPATCHAsync(Id);

                return _mapper.Map<Response<int>>(result);
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }

        }
    }
}
