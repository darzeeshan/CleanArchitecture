using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients.Validations;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Commands
{
    public class UpdateClientSetupCommandHandler : IRequestHandler<UpdateClientSetupCommandRequest, BaseCommandResponse>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public UpdateClientSetupCommandHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateClientSetupCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new ClientEditSetupValidator();
            var validationResult = await validator.ValidateAsync(request.updateClientSetupDto);

            if (validationResult.IsValid == false)
            {
                response.ReferenceId = request.Id;
                response.StatusCode = 100;
                response.ReasonCode = 15;
                response.Message = Messages.Info(15);
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var query = await _clientSetupRepository.Get(request.Id);

                if (query == null)
                {
                    response.ReferenceId = request.Id;
                    response.StatusCode = 100;
                    response.ReasonCode = 10;
                    response.Message = Messages.Info(10);
                }
                else
                {
                    _mapper.Map(request.updateClientSetupDto, query);

                    await _clientSetupRepository.Update(query);

                    response.ReferenceId = request.Id;
                    response.StatusCode = 200;
                    response.ReasonCode = 2;
                    response.Message = Messages.Info(2);
                }
            }

            return response;
        }
    }
}
