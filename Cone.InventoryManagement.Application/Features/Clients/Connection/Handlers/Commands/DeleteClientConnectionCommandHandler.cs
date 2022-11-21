using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Commands
{
    public class DeleteClientConnectionCommandHandler : IRequestHandler<DeleteClientConnectionCommandRequest, BaseCommandResponse>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public DeleteClientConnectionCommandHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteClientConnectionCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _clientConnectionRepository.Get(request.Id);

            if (result == null)
            {
                response.ReferenceId = request.Id;
                response.StatusCode = 100;
                response.ReasonCode = 10;
                response.Message = Messages.Validation(10);
            }
            else
            {
                await _clientConnectionRepository.Delete(result);

                response.ReferenceId = request.Id;
                response.StatusCode = 200;
                response.ReasonCode = 3;
                response.Message = Messages.Info(3);
            }

            return response;
        }
    }
}
