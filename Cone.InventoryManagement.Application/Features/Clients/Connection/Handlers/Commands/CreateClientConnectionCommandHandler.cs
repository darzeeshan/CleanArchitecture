using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients.Validations;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using Cone.InventoryManagement.Domain.Entities;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Commands
{
    public class CreateClientConnectionCommandHandler : IRequestHandler<CreateClientConnectionCommandRequest, BaseCommandResponse>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public CreateClientConnectionCommandHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateClientConnectionCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new ClientCreateConnectionValidator();
            var validationResult = await validator.ValidateAsync(request.createClientConnectionDto);

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
                var query = _mapper.Map<tblMapClientConnection>(request.createClientConnectionDto);
                var entity = await _clientConnectionRepository.Add(query);

                response.ReferenceId = entity.intClientConnectionId;
                response.StatusCode = 200;
                response.ReasonCode = 1;
                response.Message = Messages.Info(1);
            }

            return response;
        }
    }
}
