using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients.Validations;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using Cone.InventoryManagement.Domain.Entities;
using Cone.InventoryManagement.Settings.Access;
using MediatR;
using System.Net;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Commands
{
    public class CreateClientSetupCommandHandler : IRequestHandler<CreateClientSetupCommandRequest, BaseCommandResponse>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public CreateClientSetupCommandHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateClientSetupCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new ClientCreateSetupValidator();
            var validationResult = await validator.ValidateAsync(request.createClientSetupDto);

            if (validationResult.IsValid == false)
            {
                response.ReferenceId = 0;
                response.StatusCode = 100;
                response.ReasonCode = 15;
                response.Message = Messages.Info(15);
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                //read json settings file from settings library
                JsonSettingsFile.ReadJsonFile("\\Settings\\clientfilestorage.json");

                //read path and save nodes in variable
                string storagefolder = JsonSettingsFile.GetParentNodeValue("AssetsPhysicalLocation", "Storage");
                string clientfoldername = JsonSettingsFile.GetParentNodeValue("ClientsFileStorage", "Clients", "Root");

                //client folder converted to lower
                string clientfolder = storagefolder +""+ clientfoldername + "\\"+ request.createClientSetupDto.FolderLocation.ToLower();

                //check if client folder already exist
                if (Directory.Exists(clientfolder))
                {
                    List<string> err = new List<string>();
                    err.Add(Messages.Info(16));

                    response.ReferenceId = 0;
                    response.StatusCode = 100;
                    response.ReasonCode = 15;
                    response.Message = Messages.Info(15);
                    response.Errors = err;
                }
                else
                {
                    //convert to lowercase
                    request.createClientSetupDto.FolderLocation = request.createClientSetupDto.FolderLocation.ToLower();

                    var query = _mapper.Map<tblMapClientSetup>(request.createClientSetupDto);
                    var entity = await _clientSetupRepository.Add(query);

                    //read and save key value pair
                    IDictionary<string, string> folders = JsonSettingsFile.GetKeyPairNodeValue("ClientsFileStorage", "Shipment850");

                    foreach (KeyValuePair<string, string> kv in folders)
                    {
                        Directory.CreateDirectory(clientfolder + "" + kv.Value);
                    }

                    response.ReferenceId = entity.intClientSetupId;
                    response.StatusCode = 200;
                    response.ReasonCode = 1;
                    response.Message = Messages.Info(1);
                }
            }

            return response;
        }
    }
}
