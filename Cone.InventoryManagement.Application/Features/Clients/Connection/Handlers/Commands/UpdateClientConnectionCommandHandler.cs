using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients.Validations;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Commands
{
    public class UpdateClientConnectionCommandHandler : IRequestHandler<UpdateClientConnectionCommandRequests, BaseCommandResponse>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public UpdateClientConnectionCommandHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateClientConnectionCommandRequests request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new ClientEditConnectionValidator();
            var validationResult = await validator.ValidateAsync(request.updateClientConnectionDto);

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
                var query = await _clientConnectionRepository.Get(request.Id);

                if (query == null)
                {
                    response.ReferenceId = request.Id;
                    response.StatusCode = 100;
                    response.ReasonCode = 10;
                    response.Message = Messages.Info(10);
                }
                else
                {
                    request.updateClientConnectionDto.LastUpdated = DateTime.Now;

                    _mapper.Map(request.updateClientConnectionDto, query);

                    await _clientConnectionRepository.Update(query);

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
